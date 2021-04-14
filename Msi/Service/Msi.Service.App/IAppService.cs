namespace Msi.Service.App
{
    public interface IAppService : ITransientService
    {
        public string GetOrganizationId();

        string GetServerUrl();
    }
}
