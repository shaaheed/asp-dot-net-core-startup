using Comment.Application.Commands.Sync.Models;
using Msi.Mediator.Abstractions;
using System.Collections.Generic;

namespace Application.Commands
{
    public class SyncCommand : ICommand<object>
    {
        public ICollection<ScanCommandModel> Commands { get; set; }
    }

}
