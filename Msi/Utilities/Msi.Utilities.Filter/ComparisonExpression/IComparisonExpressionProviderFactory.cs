namespace Msi.Utilities.Filter
{
    public interface IComparisonExpressionProviderFactory
    {

        void AddProvider(string @operator, IComparisonExpressionProvider expression);

        IComparisonExpressionProvider CreateProvider(string @operator);

    }
}
