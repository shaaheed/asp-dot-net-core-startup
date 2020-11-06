//using Application.Commands;
//using Comment.Persistence;
//using Msi.Mediator.Abstractions;
//using Msi.Extensions.Persistence;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Application.Users.Queries
//{
//    public class SyncCommandHandler : ICommandHandler<SyncCommand, object>
//    {

//        public IUnitOfWork<CommentDataContext> _unitOfWork;

//        public SyncCommandHandler(IUnitOfWork<CommentDataContext> unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public Task<object> Handle(SyncCommand request, CancellationToken cancellationToken)
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
