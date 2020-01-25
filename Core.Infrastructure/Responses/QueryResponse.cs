namespace Core.Infrastructure.Responses
{
    public class QueryResponse<T>
    {
        public int StatusCode { get; protected set; }
        public T Data { get; set; }

    }
}
