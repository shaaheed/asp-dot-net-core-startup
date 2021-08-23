namespace Msi.Utilities.Filter
{
    public class FilterUtilitiesOptions
    {
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
                    }
                };
            }
        }

    }
}
