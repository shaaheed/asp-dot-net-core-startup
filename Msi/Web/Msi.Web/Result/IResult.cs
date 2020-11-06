namespace Msi.Web
{
    public interface IResult
    {
        int Status { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
