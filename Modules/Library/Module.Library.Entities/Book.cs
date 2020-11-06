using Module.Core.Entities;
using System.Collections.Generic;

namespace Module.Library.Entities
{
    public class Book
    {

        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Excerpt { get; set; }
        public string Isbn { get; set; }
        public float Price { get; set; }
        public string Binding { get; set; }
        public float Weight { get; set; }
        public bool HasEBook { get; set; }

        public long LanguageId { get; set; }
        public Language Language { get; set; }

        public long BookShelfId { get; set; }
        public BookShelf BookShelf { get; set; }
        public int RackNumber { get; set; }

        public long AuthorId { get; set; }
        public Author Author { get; set; }

        public long PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
