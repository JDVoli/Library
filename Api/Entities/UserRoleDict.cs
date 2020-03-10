using System;
using System.Collections.Generic;

namespace Library.Entities
{
    public partial class UserRoleDict
    {
        public UserRoleDict()
        {
            User = new HashSet<User>();
        }

        public int IdUserRoleDict { get; set; }
        public string Role { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
