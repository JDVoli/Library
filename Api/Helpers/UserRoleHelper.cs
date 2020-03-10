using System.Collections.Generic;

namespace Library.Helpers
{
    public static class UserRoleHelper
    {
        public static Dictionary<string, int> UserRoles => new Dictionary<string, int>
        {
            {"Admin", 1},
            {"Reader", 2}
        };

        public enum UserRolesEnum
        {
            Admin = 1,
            Reader = 2
        }
    }
}
