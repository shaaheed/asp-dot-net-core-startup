using System;

namespace Module.Constructions.Domain
{
    public class UpdateFootingCommand : CreateFootingCommand
    {
        public Guid Id { get; set; }
    }
}
