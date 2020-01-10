using System.Threading.Tasks;
using Library.Entities;
using Library.Models.DTO;
using Library.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<User> Login(LoginDto login)
        {
            var userFromDb = await _context.User.Include(x => x.IdUserRoleDictNavigation).SingleOrDefaultAsync(x => x.Login == login.Login);

            if (userFromDb == null)
                return null;

            return new PasswordHasher().VerifyHashedPassword(userFromDb.Password, login.Password) ==
                   PasswordVerificationResult.Success ? userFromDb : null;
        }
    }
}
