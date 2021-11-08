using System;
using System.Collections.Generic;
namespace Msi.Utilities.Filter
{
    public class ExpressionProviderFactory : IExpressionProviderFactory
    {

        private Dictionary<string, IExpressionProvider> _providers = new Dictionary<string, IExpressionProvider>
        {
            { "eq", new EqualExpressionProvider() },
            { "ne", new NotEqualExpressionProvider() },
            { "gt", new GreaterThanExpressionProvider() },
            { "ge", new GreaterThanOrEqualExpressionProvider() },
            { "lt", new LessThanExpressionProvider() },
            { "le", new LessThanOrEqualExpressionProvider() },
            { "like", new LikeExpressionProvider() },
            { "contains", new LikeExpressionProvider() },
            { "startswith", new StartsWithExpressionProvider() },
            { "endswith", new EndsWithExpressionProvider() }
        };

        public void AddProvider(string @operator, IExpressionProvider expression)
        {
            _providers.Add(@operator, expression);
        }

        public IExpressionProvider CreateProvider(string @operator)
        {
            if (_providers.ContainsKey(@operator))
            {
                return _providers[@operator];
            }
            throw new ArgumentException($"Operator '{@operator}' is not supported.");
        }

    }
}
