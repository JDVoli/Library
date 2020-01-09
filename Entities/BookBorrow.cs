using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public partial class BookBorrow
    {
        public int IdBookBorrow { get; set; }
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Comments { get; set; }

        public virtual Book IdBookNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
