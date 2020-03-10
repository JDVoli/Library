using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public partial class Book
    {
        public Book()
        {
            BookBorrow = new HashSet<BookBorrow>();
        }

        public int IdBook { get; set; }
        public string Title { get; set; }
        public int IdAuthor { get; set; }
        public string PublishYear { get; set; }
        public int IdCityDict { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual CityDict IdCityDictNavigation { get; set; }
        public virtual ICollection<BookBorrow> BookBorrow { get; set; }
    }
}
