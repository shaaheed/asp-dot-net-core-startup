using Module.Sales.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Constructions.Entities
{
    [Table(nameof(Client), Schema = SchemaConstants.Constructions)]
    public class Client : BaseContact
    {
        //
    }
}
