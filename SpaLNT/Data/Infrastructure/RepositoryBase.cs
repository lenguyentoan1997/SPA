using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Models.Spa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace SpaLNT.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private SpaDbContext _db;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; private set; }
        protected SpaDbContext DbContext { get { return _db ?? (_db = DbFactory.Init()); } }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        #region Implementation
        //
        public virtual void Add(T entity) => _dbSet.Add(entity);

        //
        public virtual void Remove(T entity) => _dbSet.Remove(entity);

        //
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        //
        public virtual async Task<T> FindByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        //
        public virtual async Task<IEnumerable<T>> GetAllAsync(int page, int pageSize)
        {
            var listT = await _dbSet.ToListAsync();

            return listT.ToPagedList(page, pageSize);
        }

        #endregion
    }
}