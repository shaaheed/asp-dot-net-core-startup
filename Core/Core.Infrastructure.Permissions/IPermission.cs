namespace Core.Infrastructure.Permissions
{
    public interface IPermission
    {
        string Name { get; set; }
        string Description { get; set; }
        string Group { get; set; }
    }
}
