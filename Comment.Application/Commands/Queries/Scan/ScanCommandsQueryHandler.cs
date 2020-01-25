using Application.Commands;
using Comment.Application.Commands.Sync.Models;
using Core.Infrastructure.Commands;
using Core.Infrastructure.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class ScanCommandsQueryHandler : IQueryHandler<ScanCommandsQuery, ICollection<ScanCommandModel>>
    {

        public ScanCommandsQueryHandler()
        {
            //
        }

        public async Task<ICollection<ScanCommandModel>> Handle(ScanCommandsQuery request, CancellationToken cancellationToken)
        {
            var result = await Task.Factory.StartNew(() =>
            {
                List<ScanCommandModel> commands = new List<ScanCommandModel>();
                var types = typeof(SyncCommand).Assembly.ExportedTypes;
                foreach (var type in types)
                {
                    if (type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICommand<>)))
                    {
                        var command = new ScanCommandModel
                        {
                            Name = type.Name,
                            Properties = type.GetProperties().Select(x => new ScanCommandPropertyModel
                            {
                                Name = x.Name,
                                Type = x.PropertyType.Name
                            }).ToList()
                        };
                        commands.Add(command);
                    }
                }
                return commands;
            }, cancellationToken);

            return result;
        }
    }
}
