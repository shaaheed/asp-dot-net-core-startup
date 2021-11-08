using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Msi.Utilities.Filter
{
    public class StartsWithExpressionProvider : IExpressionProvider
    {

        private static MethodInfo method = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });

        public Expression GetExpression(Expression left, Expression right)
        {
            var methodExpression = Expression.Call(left, method, new Expression[] { right });
            return Expression.Equal(methodExpression, Expression.Constant(true));
        }
    }
}
