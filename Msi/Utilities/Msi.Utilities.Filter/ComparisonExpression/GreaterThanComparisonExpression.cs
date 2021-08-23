using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class GreaterThanComparisonExpression : IComparisonExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }
    }
}
