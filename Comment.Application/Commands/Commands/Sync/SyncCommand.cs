using Comment.Application.Commands.Sync.Models;
using Core.Infrastructure.Commands;
using System.Collections.Generic;

namespace Application.Commands
{
    public class SyncCommand : ICommand<object>
    {
        public ICollection<ScanCommandModel> Commands { get; set; }
    }

}
