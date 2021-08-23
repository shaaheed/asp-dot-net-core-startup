using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Msi.Utilities.Expressions;

namespace Msi.Utilities.Filter
{
    public class Parser
    {

        private static Type _dateTimeOffsetType = typeof(DateTimeOffset);
        private static Dictionary<string, PropertyInfo[]> _properties = new Dictionary<string, PropertyInfo[]>();

        // operator with precedence
        // higer value means higer precedence
        private static Dictionary<string, int> _operators = new Dictionary<string, int> {
            { "or", 1 },
            { "and", 2 }
        };

        private static Tokenizer _tokenizer;
        private static IComparisonExpressionProviderFactory _factory;

        public IEnumerable<Token> Tokenize(string text)
        {
            if (_tokenizer == null)
            {
                _tokenizer = new Tokenizer();
            }

            _tokenizer.Reset();
            var token = _tokenizer.GetNextToken(text);
            var tokens = new List<Token> { token };
            while (token.Type != TokenType.Eof)
            {
                token = _tokenizer.GetNextToken(text);
                tokens.Add(token);
            }
            return tokens;
        }

        public IEnumerable<Token> ToShuntingYard(IEnumerable<Token> infix)
        {
            Stack<Token> stack = new Stack<Token>();
            List<Token> outputs = new List<Token>();
            foreach (var token in infix)
            {
                if (token.Type == TokenType.Eof)
                {
                    if (stack.Count <= 0)
                        break;

                    while (stack.Count > 0)
                    {
                        outputs.Add(stack.Pop());
                    }
                    break;
                }

                if (token.Type == TokenType.Space)
                    continue;

                // if token is not operator then enqueue to queue
                string tokenValueInLowerCase = token.Value.ToLower();
                bool isOperator = _operators.ContainsKey(tokenValueInLowerCase);
                bool isParenthesis = token.Type == TokenType.LeftParentheses || token.Type == TokenType.RightParentheses;
                bool canEnqueue = token.Type == TokenType.Word && !isOperator && !isParenthesis;

                if (canEnqueue)
                {
                    outputs.Add(token);
                }
                else
                {
                    if (stack.Count <= 0 || token.Type == TokenType.LeftParentheses)
                    {
                        stack.Push(token);
                    }
                    else if (token.Type == TokenType.RightParentheses)
                    {
                        if (stack.Count > 0)
                        {
                            // find left parenthesis in stack
                            Token _token = stack.Peek();
                            if (_token.Type == TokenType.LeftParentheses)
                            {
                                stack.Pop();
                            }
                            else
                            {
                                while (_token.Type != TokenType.LeftParentheses)
                                {
                                    outputs.Add(stack.Pop());

                                    if (stack.Count <= 0)
                                        break;

                                    _token = stack.Peek();

                                    if (_token.Type == TokenType.LeftParentheses)
                                        stack.Pop();
                                }
                            }
                        }
                    }
                    else
                    {
                        Token stackTopToken = stack.Peek();
                        if (stackTopToken.Type != TokenType.LeftParentheses)
                        {
                            int currentOperatorPrecedence = _operators[tokenValueInLowerCase];
                            int stackTopOperatorPrecedence = _operators[stackTopToken.Value.ToLower()];
                            // less value means higher precedence
                            if (stackTopOperatorPrecedence > currentOperatorPrecedence)
                            {
                                // stack top operator has higer precendece
                                // 1. pop stack top token then enqueue to queue
                                // 2. push current token to stack
                                outputs.Add(stack.Pop());
                                stack.Push(token);
                            }
                            else
                            {
                                stack.Push(token);
                            }
                        }
                        else
                        {
                            stack.Push(token);
                        }
                    }
                }
            }
            return outputs;
        }

        public LambdaExpression ToExpression<T>(IEnumerable<Token> postfix)
        {
            Stack<object> stack = new Stack<object>();
            var queue = new Queue<Token>(postfix);

            string key = typeof(T).AssemblyQualifiedName;
            PropertyInfo[] properties = null;
            if (_properties.ContainsKey(key))
            {
                properties = _properties[key];
            }
            else
            {
                properties = typeof(T).GetProperties();
                _properties.Add(key, properties);
            }

            var parameter = Expression.Parameter(typeof(T), "x");

            int operatorCount = 0;
            while (queue.Count != 0)
            {
                var token = queue.Dequeue();
                string opt = token.Value.ToLower();
                bool isOperator = _operators.ContainsKey(opt);
                if (isOperator)
                {
                    operatorCount++;
                    Expression right = GetExpression(properties, parameter, stack);
                    if (right == null) continue;

                    Expression left = GetExpression(properties, parameter, stack);
                    if (left == null) continue;

                    if (opt == "and")
                    {
                        stack.Push(Expression.AndAlso(left, right));
                    }
                    else if (opt == "or")
                    {
                        stack.Push(Expression.OrElse(left, right));
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    stack.Push(token);
                }
            }
            Expression expression = null;
            if (operatorCount == 0)
            {
                expression = GetExpression(properties, parameter, stack);
            }
            else
            {
                expression = stack.Pop() as Expression;
            }

            // x => x.Property == "Value"
            if (expression == null) return null;

            var lambda = parameter.GetLambda<T, bool>(expression);
            return lambda;
        }

        private Expression GetExpression(PropertyInfo[] properties, ParameterExpression parameter, Stack<object> stack)
        {
            object obj = stack.Pop();
            if (obj is Expression)
            {
                return obj as Expression;
            }
            else if (obj is Token)
            {
                Token valueToken = obj as Token; 
                Token operatorToken = stack.Pop() as Token;
                Token propertyToken = stack.Pop() as Token;

                string[] propertyNames = propertyToken.Value.Split('.');
                var propertyInfo = properties.FirstOrDefault(x => x.Name == propertyNames[0]);

                if (propertyInfo == null) return null;

                //bool isFilterable = propertyInfo.GetCustomAttributes<SearchableAttribute>().FirstOrDefault() != null;

                //if (!isFilterable) return null;

                // x.Property
                var left = parameter.GetPropertyExpression(propertyInfo);

                if (propertyNames.Length > 1)
                {
                    left = propertyNames.Skip(1).Aggregate(left, Expression.Property);
                }

                var propertyType = GetSafePropertyType(propertyInfo);
                if (propertyNames.Length > 1)
                {
                    foreach (var tokenPart in propertyNames.Skip(1))
                    {
                        propertyInfo = propertyType.GetProperty(tokenPart);
                        propertyType = GetSafePropertyType(propertyInfo);
                    }
                }

                var converter = TypeDescriptor.GetConverter(propertyType);
                var convertedValue = converter.ConvertFromInvariantString(valueToken.Value);

                //object constantValue = null;
                //if (propertyType.IsEnum)
                //{
                //    constantValue = Enum.Parse(propertyType, valueToken.Value);
                //}
                //else if (propertyType == _dateTimeOffsetType)
                //{
                //    DateTimeOffset.TryParse(valueToken.Value, out DateTimeOffset value);
                //    if (value == null || value == default) return null;
                //    constantValue = value;
                //}
                //else
                //{
                //    if (!valueToken.Value.Equals("NULL"))
                //    {
                //        constantValue = Convert.ChangeType(valueToken.Value, propertyType);
                //    }
                //}

                // Value
                var right = Expression.Constant(convertedValue, propertyInfo.PropertyType);

                // x.Property == "Value"
                var opt = operatorToken.Value.ToLower();
                if (_factory == null)
                {
                    _factory = new ComparisonExpressionProviderFactory();
                }

                var provider = _factory.CreateProvider(opt);
                var expression = provider.GetExpression(left, right);
                return expression;
            }
            else
            {
                throw new Exception("Invalid object in stack.");
            }
        }

        private static Type GetSafePropertyType(PropertyInfo propertyInfo)
        {
            var nullable = Nullable.GetUnderlyingType(propertyInfo.PropertyType);
            return nullable ?? propertyInfo.PropertyType;
        }
    }
}
