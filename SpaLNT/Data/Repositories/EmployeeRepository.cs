using SpaLNT.Data.Infrastructure;
using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories.Interfaces;
using SpaLNT.Models.Spa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace SpaLNT.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory) { }
        //
        public virtual async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, Branch>> expression, int page, int pageSize)
        {
            var listT = await DbContext.Employees.Include(expression).ToListAsync();
            return listT.ToPagedList(page, pageSize);
        }
    }
}