namespace Msi.Utilities.Filter
{
    public class FilterOptions : IFilterOptions
    {
        // Paging
        public int? Offset { get; set; }
        public int? Limit { get; set; }

        // Search
        public string[] Search { get; set; }

        // Filter
        public string Filter { get; set; }

        // Sort 
        public string[] OrderBy { get; set; }
    }
}
