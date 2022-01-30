using SpaLNT.Areas.Admin.Hubs;
using SpaLNT.Models.Spa;
using SpaLNT.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class EmployeesController : Controller
    {
        #region Initialize
        private SpaDbContext db = new SpaDbContext();
        private IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        // GET: Admin/Employees
        public async Task<ActionResult> Index()
        {
            ViewData["ControllerName"] = "Employees";

            //var employees = db.Employees.Include(e => e.Branch);
            //TempData["EmployeesData"] = await employees.ToListAsync();

            TempData["EmployeesData"] = await _employeeService.GetAllAsync(1, 4);

            return View();
        }

        public async Task<ActionResult> GetAllData(int page = 1, int pageSize = 4)
        {
            if (TempData["EmployeeData"] == null)
            {
                TempData["EmployeeData"] = await _employeeService.GetAllAsync(page, pageSize);

                return PartialView("_DataList", TempData["EmployeeData"]);
            }

            var employeesData = TempData["EmployeeData"] as IEnumerable<Employee>;

            return PartialView("_DataList", employeesData);
        }

        // GET: Admin/Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Admin/Employees/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            return View();
        }

        // POST: Admin/Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Avatar,Phone,Email,Salary,EmployeeCode,BranchId,Gender,DOB")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(employee.Avatar))
                {
                    employee.Avatar = "person_default.jpg";
                }
                else
                {
                    employee.Avatar = SaveImgInProject(employee.Name); ;
                }

                db.Employees.Add(employee);
                int result = await db.SaveChangesAsync();
                if (result == 1)
                {
                    //Realtime: When created Branch it will notification SinglrHub
                    EchoHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", employee.BranchId);
            return View(employee);
        }

        // GET: Admin/Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", employee.BranchId);
            TempData["emplAvatar"] = employee.Avatar;
            return View(employee);
        }

        // POST: Admin/Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Avatar,Phone,Email,Salary,EmployeeCode,BranchId,Gender,DOB")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;

                //check name img modified
                if (string.IsNullOrEmpty(employee.Avatar))
                {
                    employee.Avatar = TempData["emplAvatar"].ToString();
                }
                else
                {
                    employee.Avatar = SaveImgInProject(employee.Name);
                }

                int result = await db.SaveChangesAsync();
                if (result == 1)
                {
                    EchoHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", employee.BranchId);
            return View(employee);
        }

        // GET: Admin/Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Admin/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            int result = await db.SaveChangesAsync();
            if (result == 1)
            {
                //Realtime: When deleted Branch it will notification SinglrHub
                EchoHub.BroadcastData();
            }
            return RedirectToAction("Index");
        }

        //
        public string SaveImgInProject(string name)
        {
            string dateTime = DateTime.Now.ToString();
            string avatarName = name + dateTime + ".png";
            //remove characters in avatarName
            string avatarNameFormat = Regex.Replace(avatarName, "[:/ ]", "");

            //Copy img in project
            var httpContextRequestFile = HttpContext.Request.Files[0];
            string fullPathWithFileName = "~/Areas/Admin/Content/img/Employee/" + avatarNameFormat;
            httpContextRequestFile.SaveAs(Server.MapPath(fullPathWithFileName));

            return avatarNameFormat;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
