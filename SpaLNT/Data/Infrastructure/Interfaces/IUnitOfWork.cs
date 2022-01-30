using System.Threading.Tasks;

namespace SpaLNT.Data.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
