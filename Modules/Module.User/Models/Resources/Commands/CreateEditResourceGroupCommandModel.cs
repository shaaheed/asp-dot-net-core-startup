namespace Modules.User.Resources.Commands
{
    public class CreateEditResourceGroupCommandModel
    {
        public long ResourceId { get; set; }
        public long?[] OperationIds { get; set; }
    }
}
