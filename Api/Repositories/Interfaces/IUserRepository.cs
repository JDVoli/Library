using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Entities;
using Library.Models.DTO;

namespace Library.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        Task<ICollection<User>> GetUsers();

        Task<User> AddUser(UserDto userToAdd);

        Task<User> GetUser(int idUser);
    }
}
