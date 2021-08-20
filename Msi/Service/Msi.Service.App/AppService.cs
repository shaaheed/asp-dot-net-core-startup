using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Msi.Service.App
{
    public class AppService : IAppService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HttpRequest _httpRequest;
        private const string ORGANIZATION_HEADER_KEY = "x-organization-id";

        public AppService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpRequest = _httpContextAccessor.HttpContext.Request;
        }

        public string GetOrganizationId()
        {
            if (_httpRequest == null) return null;
            _httpRequest.Headers.TryGetValue(ORGANIZATION_HEADER_KEY, out StringValues organizationId);
            return organizationId.ToString();
        }

        public string GetServerUrl()
        {
            if (_httpRequest == null) return null;
            return $"{_httpRequest.Scheme}://{_httpRequest.Host}";
        }

        public string GetHttpMethod()
        {
            return _httpRequest?.Method ?? null;
        }
    }
}
