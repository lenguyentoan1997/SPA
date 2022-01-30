using SpaLNT.Models.Spa;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpaLNT.Data.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all data then auto paginate by page and pageSize
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(int page, int pageSize);

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> FindByIdAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Marks an entity as new
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
        
    }
}
