using System.Linq.Expressions;

namespace Msi.Utilities.Filter
{
    public interface IExpressionProvider
    {
        Expression GetExpression(Expression left, Expression right);
    }
}
