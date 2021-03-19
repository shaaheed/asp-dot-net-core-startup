namespace Module.Systems.Domain
{
    public class CodeNameDto<T> : IdNameDto<T>
    {
        public string Code { get; set; }
    }
}
