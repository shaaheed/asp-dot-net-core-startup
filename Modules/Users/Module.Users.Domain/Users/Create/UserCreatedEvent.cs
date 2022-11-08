using Module.Accounts.Entities;
using Msi.Data.Abstractions;
using Msi.Mediator.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Accounts.Domain
{
    public class UserCreatedEvent : EventBase
    {
        
    }

    public class UserPipeline : IUnitOfWorkPipeline<User>
    {
        public async Task<User> Handle(User entity, CancellationToken cancellationToken, PipelineHandlerDelegate<User> next)
        {
            //entity.Id = 1;
            var n = await next();
            return n;
        }
    }

    public class UserPipeline2 : IUnitOfWorkPipeline<User>
    {
        public async Task<User> Handle(User entity, CancellationToken cancellationToken, PipelineHandlerDelegate<User> next)
        {
            //entity.Id = 2;
            var n = await next();
            return n;
        }
    }
}
