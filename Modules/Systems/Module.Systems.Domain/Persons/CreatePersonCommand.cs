using Module.Systems.Entities;

namespace Module.Systems.Domain.Persons
{
    public class CreatePersonCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }

        public virtual Person Map(Person entity = null)
        {
            entity = entity ?? new Person();
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.Email = Email;
            entity.Phone = Phone;
            entity.Mobile = Mobile;
            return entity;
        }
    }
}
