namespace Msi.Utilities.Filter
{
    public interface IPagingOptions
    {
        int? Offset { get; set; }
        int? Limit { get; set; }
    }
}
