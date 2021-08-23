using System.Text;

namespace Msi.Utilities.Filter
{
    public class Tokenizer : ITokenizer
    {
        private int _currentPosition = 0;
        private StringBuilder _builder = new StringBuilder();

        public void Reset()
        {
            _currentPosition = 0;
        }

        public Token GetNextToken(string text)
        {
            while (true)
            {
                int position = _currentPosition;
                if (_currentPosition >= text.Length)
                {
                    return new Token(position, TokenType.Eof);
                }

                char c = text[_currentPosition++];
                if (c == '(')
                {
                    return new Token(position, TokenType.LeftParentheses, "(");
                }
                else if (c == ')')
                {
                    return new Token(position, TokenType.RightParentheses, ")");
                }
                //else if (c == '\'')
                //{
                //    return new Token(position, TokenType.SingleQuote, "'");
                //}
                //else if (c == '"')
                //{
                //    return new Token(position, TokenType.DoubleQuote, "\"");
                //}
                else if (c == ' ')
                {
                    // check next consecutive char is space, collect them and treat as spcae
                    int startPosition = position;
                    _builder.Length = 0;
                    while (c == ' ' && _currentPosition < text.Length)
                    {
                        _builder.Append(c);
                        c = text[_currentPosition++];
                    }
                    _currentPosition--;
                    return new Token(startPosition, TokenType.Space, _builder.ToString());
                }
                else if (c != ' ')
                {
                    int startPosition = position;
                    _builder.Length = 0;
                    _builder.Append(c);
                    while (_currentPosition < text.Length)
                    {
                        if (c == '"' || c == '\'')
                        {
                            while (_currentPosition < text.Length)
                            {
                                c = text[_currentPosition++];
                                _builder.Append(c);
                                if (c == '"' || c == '\'')
                                    break;
                            }
                            return new Token(startPosition, TokenType.Word, _builder.ToString().Trim('"', '\''));
                        }

                        c = text[_currentPosition++];
                        if (IsSeperator(c))
                        {
                            _currentPosition--;
                            break;
                        }

                        _builder.Append(c);
                    }
                    return new Token(startPosition, TokenType.Word, _builder.ToString().Trim('"', '\''));
                }
            }
        }

        private bool IsSeperator(char c)
        {
            return c == ' ' || c == '(' || c == ')' /*|| c == '\'' || c == '"'*/;
        }
    }
}
