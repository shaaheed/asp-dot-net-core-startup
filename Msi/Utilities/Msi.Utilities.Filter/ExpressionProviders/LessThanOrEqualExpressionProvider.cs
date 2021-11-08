using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    internal class LessThanOrEqualExpressionProvider : IExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right);
        }
    }
}
