using System.Threading.Tasks;
using Library.Models.DTO;

namespace Library.Repositories.Interfaces
{
    public interface IAccountRepository : IBaseRepository
    {
        Task<bool> Login(LoginDto login);
    }
}
