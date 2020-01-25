using System.Threading.Tasks;

namespace Core.Infrastructure.Responses
{
    public struct Unit
    {
        public static readonly Unit Value;
        public static readonly Task<Unit> Task;
    }
}
