using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
