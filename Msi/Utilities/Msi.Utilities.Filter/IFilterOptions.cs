namespace Msi.Utilities.Filter
{
    public interface IFilterOptions
    {
        int? Offset { get; set; }
        int? Limit { get; set; }
        string[] Search { get; set; }
        string[] OrderBy { get; set; }
        string Filter { get; set; }
    }
}
