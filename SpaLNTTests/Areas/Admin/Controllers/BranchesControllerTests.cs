using Moq;
using NUnit.Framework;
using SpaLNT.Models.Spa;
using SpaLNT.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaLNT.Areas.Admin.Controllers.Tests
{
    [TestFixture]
    public class BranchesControllerTests
    {
        #region Initialize
        private Mock<IBranchService> _mockBranchService;
        private BranchesController _branchesController;

        [OneTimeSetUp]
        public void Initialize()
        {
            _mockBranchService = new Mock<IBranchService>();
            _branchesController = new BranchesController(_mockBranchService.Object);

        }
        #endregion

        /// <summary>
        /// Testing Create with HttpPost attribute Valid ModelState the RedirectToRouteResult 
        /// to Check for the Redirect to Index Action
        /// </summary>
        [Test]
        public async Task Test_BranchesController_Create_POST_Redirect()
        {
            //Arrange
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

            _mockBranchService.Setup(x => x.Add(It.IsAny<Branch>()));

            //Act
            RedirectToRouteResult result = await _branchesController.Create(branch) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
        }

        /// <summary>
        /// Testing Create with HttpPost attribute Invaild ModelState the PartialViewResult
        /// to Check for the PartialView name to _Create
        /// </summary>
        [Test]
        public async Task Test_BranchesController_Create_POST_InvaildModelState()
        {
            //Arrange
            var branch = new Branch()
            {
                Id = 4,
                BranchName = "LNT Spa",
                Address = "109 Hung Vuong",
                Phone = null,
                Email = "lnt01@gmail.com",
                ContactVia = "Lê Nguyễn Toàn",
                BranchCode = "CN5"
            };

            _mockBranchService.Setup(x => x.Add(It.IsAny<Branch>()));

            _branchesController.ModelState.AddModelError("Phone", "Phone is required");

            //Act
            var result = await _branchesController.Create(branch) as PartialViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "_Create");
        }
    }
}