using Module.Users.Entities;
using Msi.Mediator.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Users.Domain
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public GetUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetAsync(x => x.Id == request.Id, UserDto.Selector(), cancellationToken);
        }
    }
}
