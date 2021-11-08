namespace Msi.Utilities.Filter
{
    public interface IExpressionProviderFactory
    {

        void AddProvider(string @operator, IExpressionProvider expression);

        IExpressionProvider CreateProvider(string @operator);

    }
}
