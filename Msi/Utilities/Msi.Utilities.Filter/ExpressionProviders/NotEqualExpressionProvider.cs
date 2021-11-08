using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class NotEqualExpressionProvider : IExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }
    }
}
