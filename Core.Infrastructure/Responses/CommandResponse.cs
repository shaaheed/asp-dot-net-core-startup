namespace Core.Infrastructure.Responses
{
    public class CommandResponse<TData>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; } = default;

        public CommandResponse(TData data, int code, string message)
        {
            Data = data;
            Code = code;
            Message = message;
        }

    }
}
