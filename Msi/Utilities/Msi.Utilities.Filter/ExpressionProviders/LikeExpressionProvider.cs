using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Msi.Utilities.Filter
{
    public class LikeExpressionProvider : IExpressionProvider
    {

        private static MethodInfo method = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });

        public Expression GetExpression(Expression left, Expression right)
        {
            var methodExpression = Expression.Call(left, method, new Expression[] { right });
            return Expression.Equal(methodExpression, Expression.Constant(true));
        }
    }
}
