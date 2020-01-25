//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Comment.Application.Comment.Events;
//using Comment.Persistence;
//using Core.Events;
//using Core.Infrastructure.Commands;
//using Core.Infrastructure.Exceptions;
//using Msi.Extensions.Persistence;

//namespace Comment.Application.Comment.Commands
//{
//    public class CommentCommandHandler :
//        ICommandHandler<CreateCommentCommand, object>,
//        ICommandHandler<DeleteCommentCommand, object>
//    {

//        private readonly IUnitOfWork<CommentDataContext> _unitOfWork;
//        private readonly IEventBus _eventBus;

//        public CommentCommandHandler(
//            IUnitOfWork<CommentDataContext> unitOfWork,
//            IEventBus eventBus)
//        {
//            _unitOfWork = unitOfWork;
//            _eventBus = eventBus;
//        }

//        public async Task<object> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
//        {

//            var repo = _unitOfWork.GetRepository<Domain.Entities.Comment>();
//            var comment = new Domain.Entities.Comment {
//                Content = request.Content
//            };

//            comment.Append(new CommentCreatedEvent {
//                Id = new Random().Next(int.MinValue, int.MaxValue),
//                Content = comment.Content
//            });

//            await repo.AddAsync(comment);
//            await _unitOfWork.SaveChangesAsync(cancellationToken);

//            _eventBus.Publish(comment.PendingEvents.ToArray(), cancellationToken);

//            return Task.CompletedTask;
//        }

//        public async Task<object> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
//        {

//            var repo = _unitOfWork.GetRepository<Domain.Entities.Comment>();
//            var comment = await repo.FirstOrDefaultAsync(x => x.Id == request.Id);

//            if (comment == null)
//                new DeleteFailureException("", "");

//            repo.Remove(comment);
//            await _unitOfWork.SaveChangesAsync();
//            return Task.CompletedTask;
//        }
//    }
//}
