using System.Threading.Tasks;

namespace Library.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        Task<bool> SaveChanges();
    }
}
