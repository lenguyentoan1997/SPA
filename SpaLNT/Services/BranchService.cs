using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories.Interfaces;
using SpaLNT.Models.Spa;
using SpaLNT.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace SpaLNT.Services
{
    public class BranchService : IBranchService
    {
        private IBranchRepository _branchRepository;

        private IUnitOfWork _unitOfWork;

        public BranchService(IBranchRepository branchRepository, IUnitOfWork unitOfWork)
        {
            _branchRepository = branchRepository;
            _unitOfWork = unitOfWork;
        }

        //
        public async Task<IEnumerable<Branch>> GetAllAsync(int page, int pageSize)
        {
            return await _branchRepository.GetAllAsync(page, pageSize);
        }

        //
        public async Task<Branch> FindByIdAsync(Expression<Func<Branch,bool>> expression)
        {
            return await _branchRepository.FindByIdAsync(expression);
        }

        //
        public void Add(Branch branch)
        {
            _branchRepository.Add(branch);
        }

        //
        public void Update(Branch branch)
        {
            _branchRepository.Update(branch);
        }

        //
        public void Remove(Branch branch)
        {
            _branchRepository.Remove(branch);
        }

        //
        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}