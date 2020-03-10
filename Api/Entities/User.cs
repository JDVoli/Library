using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public partial class User
    {
        public User()
        {
            BookBorrow = new HashSet<BookBorrow>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdUserRoleDict { get; set; }

        public virtual UserRoleDict IdUserRoleDictNavigation { get; set; }
        public virtual ICollection<BookBorrow> BookBorrow { get; set; }
    }
}
