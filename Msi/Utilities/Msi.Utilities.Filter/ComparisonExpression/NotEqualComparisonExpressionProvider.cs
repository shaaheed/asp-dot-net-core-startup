using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class NotEqualComparisonExpressionProvider : IComparisonExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }
    }
}
