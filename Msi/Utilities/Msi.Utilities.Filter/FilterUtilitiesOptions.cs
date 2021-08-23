namespace Msi.Utilities.Filter
{
    public class FilterUtilitiesOptions
    {
        public IComparisonExpressionProviderFactory ComparisonExpressionProviderFactory { get; set; }

        public FilterOptions Options { get; set; }

        public static FilterUtilitiesOptions DefaultOptions
        {
            get
            {
                return new FilterUtilitiesOptions
                {
                    Options = new FilterOptions
                    {
                        Limit = 20,
                        Offset = 0
                    },
                    ComparisonExpressionProviderFactory = new ComparisonExpressionProviderFactory()
                };
            }
        }

    }
}
