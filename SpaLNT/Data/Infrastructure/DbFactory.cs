using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Models.Spa;

namespace SpaLNT.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SpaDbContext _db;

        public SpaDbContext Init()
        {
            //The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null.
            //Otherwise, it evaluates the right-hand operand and returns its result
            return _db ?? (_db = new SpaDbContext());
        }

        protected override void DisposeCore()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}