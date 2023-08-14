using Msi.Data.Abstractions;
using Msi.Data.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Msi.Mediator.Abstractions
{
    public class CreateCommandHandler<TEntity, TCreateCommand> : ICommandHandler<TCreateCommand, Guid?>
        where TEntity : BaseEntity
        where TCreateCommand : ICreateCommand<Guid?>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<Guid?> Handle(TEntity entity, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<TEntity>();
            await repo.AddAsync(entity, cancellationToken);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0 ? entity.Id : null;
        }

        public virtual Task<Guid?> Handle(TCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
