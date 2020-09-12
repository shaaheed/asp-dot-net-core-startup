using Msi.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Data.Abstractions
{

    public delegate Task<TEntity> PipelineHandlerDelegate<TEntity>() where TEntity : IEntity;

    public interface IUnitOfWorkPipeline<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Handle(TEntity entity, CancellationToken cancellationToken, PipelineHandlerDelegate<TEntity> next);
    }
}
