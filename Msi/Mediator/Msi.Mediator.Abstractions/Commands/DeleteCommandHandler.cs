using Msi.Data.Abstractions;
using Msi.Data.Entity;

namespace Msi.Mediator.Abstractions
{
    public class DeleteCommandHandler<TEntity, TDeleteCommand> : ICommandHandler<TDeleteCommand, bool>
        where TEntity : BaseEntity
        where TDeleteCommand : IDeleteCommand<bool>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(TDeleteCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<TEntity>();
            var entity = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity == null)
                throw new Exception("Resource not found");

            repo.Remove(entity);
            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
