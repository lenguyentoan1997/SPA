using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Models.Spa;
using System.Threading.Tasks;

namespace SpaLNT.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private SpaDbContext _db;

        public UnitOfWork(IDbFactory dbFactory) => _dbFactory = dbFactory;

        public SpaDbContext DbContext { get { return _db ?? (_db = _dbFactory.Init()); } }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}