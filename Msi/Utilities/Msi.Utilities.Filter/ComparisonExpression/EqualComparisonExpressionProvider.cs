using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class EqualComparisonExpressionProvider : IComparisonExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }
    }
}
