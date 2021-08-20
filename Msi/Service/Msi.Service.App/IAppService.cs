namespace Msi.Service.App
{
    public interface IAppService : IScopedService
    {
        public string GetOrganizationId();

        string GetServerUrl();

        string GetHttpMethod();
    }
}
