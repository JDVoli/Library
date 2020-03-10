using System.Threading.Tasks;
using Library.Entities;
using Library.Models.DTO;

namespace Library.Repositories.Interfaces
{
    public interface IAccountRepository : IBaseRepository
    {
        Task<User> Login(LoginDto login);
    }
}
