
using Moq;
using NUnit.Framework;
using SpaLNT.Data.Infrastructure.Interfaces;
using SpaLNT.Data.Repositories.Interfaces;
using SpaLNT.Models.Spa;
using SpaLNT.Services.Interfaces;
using System.Collections.Generic;

namespace SpaLNT.Services.Tests
{
    [TestFixture]
    public class BranchServiceTests
    {
        #region Initialize
        private Mock<IBranchRepository> _mockBranchRepo;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IBranchService _branchService;
        private List<Branch> _listBranch;

        [OneTimeSetUp]
        public void Initialize()
        {
            _mockBranchRepo = new Mock<IBranchRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _branchService = new BranchService(_mockBranchRepo.Object, _mockUnitOfWork.Object);
            _listBranch = new List<Branch>()
            {
                new Branch()
                {
                    Id=1,BranchName="LNT Spa",Address="110 abc",Phone="0935123321",Email="lnt02@gmail.com",ContactVia="Le nguyen Toan",BranchCode="Cn09"
                },
                new Branch()
                {
                    Id=2,BranchName="LNT Spa01",Address="110 abc",Phone="0935123321",Email="lnt02@gmail.com",ContactVia="Le nguyen Toan",BranchCode="Cn02"
                },
                 new Branch()
                {
                    Id=3,BranchName="LNT Spa01",Address="110 abc",Phone="0935123321",Email="lnt02@gmail.com",ContactVia="Le nguyen Toan",BranchCode="Cn03"
                },
            };
        }
        #endregion

        [Test]
        public void Test_Branch_Sevice_Add()
        {
            var branch = new Branch()
            {
                Id = 4,
                BranchName = "LNT Spa",
                Address = "109 Hung Vuong",
                Phone = "0935123123",
                Email = "lnt01@gmail.com",
                ContactVia = "Lê Nguyễn Toàn",
                BranchCode = "CN5"
            };

            _mockBranchRepo.Setup(x => x.Add(branch))
                .Callback((Branch b) =>
            {
                _listBranch.Add(b);
            });

            _branchService.Add(branch);

            Assert.AreEqual(4, _listBranch.Count);
        }
    }
}