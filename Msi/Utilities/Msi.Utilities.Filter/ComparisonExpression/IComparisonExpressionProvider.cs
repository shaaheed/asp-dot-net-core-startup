using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public interface IComparisonExpressionProvider
    {
        Expression GetExpression(Expression left, Expression right);
    }
}
