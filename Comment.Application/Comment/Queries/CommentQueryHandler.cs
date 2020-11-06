//using System.Threading;
//using System.Threading.Tasks;
//using Comment.Application.Comment.Queries;
//using Comment.Persistence;
//using Msi.Mediator.Abstractions;
//using Msi.Mediator.Abstractions;
//using Msi.Extensions.Persistence;
//using Microsoft.EntityFrameworkCore;

//namespace Comment.Application.Comment.Commands
//{
//    public class CommentQueryHandler : IQueryHandler<GetCommentsQuery, object>
//    {

//        private readonly IUnitOfWork<CommentDataContext> _unitOfWork;
//        private readonly IEventBus _eventBus;

//        public CommentQueryHandler(
//            IUnitOfWork<CommentDataContext> unitOfWork,
//            IEventBus eventBus)
//        {
//            _unitOfWork = unitOfWork;
//            _eventBus = eventBus;
//        }

//        public async Task<object> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
//        {
//            var repo = _unitOfWork.GetRepository<Domain.Entities.Comment>();
//            return await repo.AsQueryable().AsNoTracking().ToListAsync();
//        }
//    }
//}
