namespace Module.Core.Domain
{
    public class CodeNameDto<T> : IdNameDto<T>
    {
        public string Code { get; set; }
    }
}
