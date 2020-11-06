using Module.Core.Entities;

namespace Module.Library.Entities
{
    public class EBook
    {
        public long BookId { get; set; }
        public Book Book { get; set; }

        public string Link { get; set; }
        public Format Format { get; set; }

    }
}
