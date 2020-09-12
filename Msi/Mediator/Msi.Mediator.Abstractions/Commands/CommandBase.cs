namespace Msi.Mediator.Abstractions
{
    public class CommandBase<TResponse> : ICommand<TResponse>
    {
        public int Source { get; set; }
    }
}
