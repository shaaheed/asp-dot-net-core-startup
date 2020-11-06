using System;
using System.Collections.Generic;

namespace Module.Library.Entities
{
    public class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
