using Module.Users.Entities;
using Msi.Mediator.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Msi.Data.Abstractions;

namespace Module.Users.Domain
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, object>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _userRepository;

        public GetUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<object> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _userRepository
                .AsQueryable()
                .Select(x => new
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                });
            return await Task.FromResult(result);
        }
    }
}
