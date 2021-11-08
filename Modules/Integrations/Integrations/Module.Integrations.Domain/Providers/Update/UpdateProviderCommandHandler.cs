using Msi.Mediator.Abstractions;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Integrations.Domain
{
    public class UpdateProviderCommandHandler : ICommandHandler<UpdateProviderCommand, long>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateProviderCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<long> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
