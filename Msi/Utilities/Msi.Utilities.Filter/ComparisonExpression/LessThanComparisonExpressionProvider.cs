using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class LessThanComparisonExpressionProvider : IComparisonExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }
    }
}
