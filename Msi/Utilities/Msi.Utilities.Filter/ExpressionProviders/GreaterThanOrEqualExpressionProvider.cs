using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class GreaterThanOrEqualExpressionProvider : IExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right);
        }
    }
}
