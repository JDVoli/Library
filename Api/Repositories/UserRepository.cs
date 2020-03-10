using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Entities;
using Library.Helpers;
using Library.Models.DTO;
using Library.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
//        private const string ReaderRole = "Reader";

        public UserRepository(LibraryContext context) : base(context)
        {
        }


        public async Task<ICollection<User>> GetUsers()
        {
            var usersFromDb = await _context.User.ToListAsync();

            return usersFromDb;
        }
        
        public async Task<User> AddUser(UserDto userToAdd)
        {
            var newUser = await _context.User.AddAsync(new User
            {
                Name = userToAdd.Name,
                Email = userToAdd.Email,
                Login = userToAdd.Login,
                Surname = userToAdd.Surname,
                Password = new PasswordHasher().HashPassword(userToAdd.Password),
                IdUserRoleDict = (int)UserRoleHelper.UserRolesEnum.Reader
            });

            await _context.SaveChangesAsync();
            
            return newUser.Entity;
        }

        public async Task<User> GetUser(int idUser)
        {
            var userFromDb = await _context.User.SingleAsync(x => x.IdUser == idUser);

            return userFromDb;
        }
    }
}
