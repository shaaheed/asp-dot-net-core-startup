using Core.Infrastructure.Responses;
using System.Threading.Tasks;

namespace Application.Common
{
    public static class Response
    {

        public static Task<CommandResponse<TData>> Created<TData>(TData data, string message = default)
        {
            return Task.FromResult(new CommandResponse<TData>(data, 204, message));
        }

        public static Task<CommandResponse<TData>> Updated<TData>(TData data, string message = default)
        {
            return Task.FromResult(new CommandResponse<TData>(data, 204, message));
        }

    }
}
