using System;

namespace Module.Systems.Domain.Persons
{
    public class UpdatePersonCommand : CreatePersonCommand
    {
        public Guid Id { get; set; }
    }
}
