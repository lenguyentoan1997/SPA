using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories.Interfaces;
using SpaLNT.Models.Spa;
using SpaLNT.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace SpaLNT.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _emplRepository;
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _emplRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Employee employee)
        {
            _emplRepository.Add(employee);
        }

        public async Task<Employee> FindByIdAsync(Expression<Func<Employee, bool>> expression)
        {
            return await _emplRepository.FindByIdAsync(expression);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(int page, int pageSize)
        {
            return await _emplRepository.GetAllAsync(page, pageSize);
        }

        public void Remove(Employee employee)
        {
            _emplRepository.Remove(employee);
        }

        public Task<int> SaveChangesAsync()
        {
            return _unitOfWork.SaveChangesAsync();
        }

        public void Update(Employee employee)
        {
            _emplRepository.Update(employee);
        }
    }
}