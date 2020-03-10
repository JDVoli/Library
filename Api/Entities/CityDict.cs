using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public partial class CityDict
    {
        public CityDict()
        {
            Book = new HashSet<Book>();
        }

        public int IdCityDict { get; set; }
        public string City { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
