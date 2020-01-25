namespace Core.Infrastructure.Commands
{
    public class CommandBase<TResponse> : ICommand<TResponse>
    {
        public string Source { get; set; }
    }
}
