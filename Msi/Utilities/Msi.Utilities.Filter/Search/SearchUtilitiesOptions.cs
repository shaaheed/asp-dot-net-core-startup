namespace Msi.Utilities.Filter
{
    public class SearchUtilitiesOptions
    {

        public IComparisonExpressionProviderFactory ComparisonExpressionProviderFactory { get; set; }

        public static SearchUtilitiesOptions DefaultOptions
        {
            get
            {
                return new SearchUtilitiesOptions
                {
                    ComparisonExpressionProviderFactory = new ComparisonExpressionProviderFactory()
                };
            }
        }

    }
}
