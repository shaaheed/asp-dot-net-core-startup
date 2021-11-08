using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public class EqualExpressionProvider : IExpressionProvider
    {
        public Expression GetExpression(Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }
    }
}
