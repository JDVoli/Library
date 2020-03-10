using System;

namespace Library.Models.DTO
{
    public class UpdateBookBorrowDto
    {
        public int IdBookBorrow { get; set; }
        public int IdBook { get; set; }
        public int IdUser { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Comments { get; set; }
    }
}
