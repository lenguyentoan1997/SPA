using SpaLNT.Models.Spa;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpaLNT.Services.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get all data then auto paginate by page and pageSize
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetAllAsync(int page, int pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<Employee> FindByIdAsync(Expression<Func<Employee, bool>> expression);

        /// <summary>
        /// Marks an entity as new
        /// </summary>
        /// <param name="employee"></param>
        void Add(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        void Update(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        void Remove(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}