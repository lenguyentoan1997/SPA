using SpaLNT.Data.Infrastructure;
using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories.Interfaces;
using SpaLNT.Models.Spa;

namespace SpaLNT.Data.Repositories
{
    public class BranchRepository : RepositoryBase<Branch>, IBranchRepository
    {
        public BranchRepository(IDbFactory dbFactory) 
            : base(dbFactory) 
        { 
        }

    }
}