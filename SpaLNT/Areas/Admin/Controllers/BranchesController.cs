using SpaLNT.Areas.Admin.Hubs;
using SpaLNT.Models.Spa;
using SpaLNT.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class BranchesController : Controller
    {
        #region Initialize
        private IBranchService _branchService;
        #endregion

        #region Constructor
        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        #endregion

        // GET: Admin/Branches
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            TempData["BranchesData"] = await _branchService.GetAllAsync(1, 4);
            ViewData["ControllerName"] = "Branches";

            return View();
        }

        //
        [HttpGet]
        public async Task<ActionResult> GetAllData(int page = 1, int pageSize = 4)
        {
            if (TempData["BranchesData"] == null)
            {
                TempData["BranchesData"] = await _branchService.GetAllAsync(page, pageSize);

                return PartialView("_DataList", TempData["BranchesData"]);
            }

            var branchesData = TempData["BranchesData"] as IEnumerable<Branch>;

            return PartialView("_DataList", branchesData);
        }


        // GET: Admin/Branches/Details/id
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await _branchService.FindByIdAsync(x => x.Id == id);
            if (branch == null)
            {
                return HttpNotFound();
            }

            return PartialView("_Details", branch);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BranchName,Address,Phone,Email,ContactVia,BranchCode")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchService.Add(branch);
                int result = await _branchService.SaveChangesAsync();

                if (result == 1)
                {
                    //Realtime: When created Branch it will notification SinglrHub
                    EchoHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }

            //return View(branch);
            return PartialView("_Create", branch);
        }

        // GET: Admin/Branches/Edit/id
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await _branchService.FindByIdAsync(x => x.Id == id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BranchName,Address,Phone,Email,ContactVia,BranchCode")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(branch).State = EntityState.Modified;
                //int result = await db.SaveChangesAsync();

                _branchService.Update(branch);
                int result = await _branchService.SaveChangesAsync();
                if (result == 1)
                {
                    //Realtime: When edited Branch it will notification SinglrHub
                    EchoHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // GET: Admin/Branches/Delete/id
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = await _branchService.FindByIdAsync(x => x.Id == id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Admin/Branches/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Branch branch = await _branchService.FindByIdAsync(x => x.Id == id);
            _branchService.Remove(branch);
            int result = await _branchService.SaveChangesAsync();
            if (result == 1)
            {
                //Realtime: When deleted Branch it will notification SinglrHub
                EchoHub.BroadcastData();
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
