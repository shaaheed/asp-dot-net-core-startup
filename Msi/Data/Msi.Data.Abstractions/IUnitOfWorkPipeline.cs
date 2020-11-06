using Msi.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{

    public delegate Task<T> PipelineHandlerDelegate<T>();

    public interface IUnitOfWorkPipeline<T>
        where T : IEntity
    {
        Task<T> Handle(T entity, CancellationToken cancellationToken, PipelineHandlerDelegate<T> next);
    }
}
