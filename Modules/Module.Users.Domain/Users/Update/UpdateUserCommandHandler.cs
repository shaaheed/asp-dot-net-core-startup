using Module.Users.Entities;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Responses;
using System.Threading;
using System.Threading.Tasks;
using Msi.Extensions.Persistence.Abstractions;

namespace Module.Users.Domain
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, CommandResponse<long>>
    {

        public readonly IUnitOfWork _unitOfWork;
        public readonly IRepository<User> _userRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.GetRepository<User>();
        }

        public async Task<CommandResponse<long>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                var result = await _unitOfWork.SaveChangesAsync();

                if (result <= 0)
                {
                    //return await Response.Created(user.Id);
                }
            }

            return null;
        }
    }
}
