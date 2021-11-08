using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class GreaterThanExpressionProvider : IExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }
    }
}
