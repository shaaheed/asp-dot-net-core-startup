using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class LessThanExpressionProvider : IExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }
    }
}
