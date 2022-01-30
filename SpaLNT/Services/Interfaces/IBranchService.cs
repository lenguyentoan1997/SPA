using SpaLNT.Models.Spa;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace SpaLNT.Services.Interfaces
{
    public interface IBranchService
    {
        /// <summary>
        /// Get all data then auto paginate by page and pageSize
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Branch>> GetAllAsync(int page, int pageSize);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<Branch> FindByIdAsync(Expression<Func<Branch, bool>> expression);

        /// <summary>
        /// Marks an entity as new
        /// </summary>
        /// <param name="branch"></param>
        void Add(Branch branch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branch"></param>
        void Update(Branch branch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branch"></param>
        void Remove(Branch branch);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
