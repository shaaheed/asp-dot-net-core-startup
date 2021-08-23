using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Systems.Services
{
    public class CacheService /*: ICacheService*/
    {

        //private readonly IDistributedCache _distributedCache;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IETagGeneratorService _eTagGeneratorService;

        private static string IF_NONE_MATCH = "If-None-Match";
        private static string ETAG = "ETag";

        public CacheService(
            IHttpContextAccessor httpContext,
            IETagGeneratorService eTagGeneratorService
            /*IDistributedCache distributedCache*/)
        {
            /*_distributedCache = distributedCache;*/
            _httpContext = httpContext;
            _eTagGeneratorService = eTagGeneratorService;
        }

        public async Task<(bool, T)> GetData<T>(Func<Task<T>> data)
        {
            var responseETag = _httpContext.HttpContext.Request.Headers[IF_NONE_MATCH].First();
            if (string.IsNullOrEmpty(responseETag))
            {
                // TODO: Redis distributed cache to be implemented
                var _data = await data();
                var newETag = _eTagGeneratorService.GetETag(_data);
                _httpContext.HttpContext.Response.Headers.Add(ETAG, newETag);
                return (false, _data);
            }
            else
            {
                var _data = await data();
                var newETag = _eTagGeneratorService.GetETag(_data);
                _httpContext.HttpContext.Response.Headers.Add(ETAG, newETag);
                if (responseETag == newETag)
                {
                    // TODO: Cache the data to Redis
                    return (true, _data);
                }
            }
            return (false, default);
        }

    }
}
