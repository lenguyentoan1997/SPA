using Moq;
using NUnit.Framework;
using SpaLNT.Data.Infrastructure;
using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories;
using SpaLNT.Data.Repositories.Interfaces;
using SpaLNT.Models.Spa;
using System.Collections.Generic;

namespace SpaLNTTests.Data.Repositories
{
    [TestFixture]
    public class BranchRepositoryTests
    {
        #region Initialize
        private IDbFactory _dbFactory;
        private IBranchRepository _branchRepository;
        private IUnitOfWork _unitOfWork;


        [OneTimeSetUp]
        public void Inittialize()
        {
            _dbFactory = new DbFactory();
            _branchRepository = new BranchRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }
        #endregion

        [Test]
        public void Test_Branch_Repository_Add()
        {
            //var branch = new Branch()
            //{
            //    Id = 0,
            //    BranchName = "LNT Spa",
            //    Address = "10911 Hung Vuong",
            //    Phone = "0935123123",
            //    Email = "lnt01@gmail.com",
            //    ContactVia = "Lê Nguyễn Toàn",
            //    BranchCode = "CN5"
            //};

            //_branchRepository.Add(branch);
            //var result = _unitOfWork.SaveChangesAsync();

            //Assert.AreEqual(1, result.Result);
        }
    }
}
