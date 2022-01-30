using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpaLNT.Models.Spa;
using X.PagedList;
using SpaLNT.Areas.Admin.Hubs;
using System.Text.RegularExpressions;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        // GET: Admin/Customers
        public async Task<ActionResult> Index()
        {
            var list = await db.Customers.ToListAsync();
            TempData["CustomersData"] = list.ToPagedList(1, 4);
            ViewData["ControllerName"] = "Customers";

            return View();
        }

        public async Task<ActionResult> GetAllData(int page = 1, int pageSize = 4)
        {
            if (TempData["CustomersData"] == null)
            {
                var list = await db.Customers.ToListAsync();
                TempData["CustomersData"] = list.ToPagedList(page, pageSize);

                return PartialView("_DataList", TempData["CustomersData"]);
            }

            var customersData = TempData["CustomersData"] as IEnumerable<Customer>;

            return PartialView("_DataList", customersData);
        }

        // GET: Admin/Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CustomerCode,Name,Phone,Email,IdentityCard,Job,Gender,DOB,Avatar")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(customer.Avatar))
                {
                    customer.Avatar = "person_default.jpg";
                }
                else
                {
                    customer.Avatar = SaveImgInProject(customer.Name); ;
                }

                db.Customers.Add(customer);
                int result = await db.SaveChangesAsync();
                if (result == 1)
                {
                    //Realtime: When created Branch it will notification SinglrHub
                    EchoHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            TempData["customerlAvatar"] = customer.Avatar;
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CustomerCode,Name,Phone,Email,IdentityCard,Job,Gender,DOB,Avatar")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;

                //check name img modified
                if (string.IsNullOrEmpty(customer.Avatar))
                {
                    customer.Avatar = TempData["customerAvatar"].ToString();
                }
                else
                {
                    customer.Avatar = SaveImgInProject(customer.Name);
                }

                int result = await db.SaveChangesAsync();
                if (result == 1)
                {
                    EchoHub.BroadcastData();
                }

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            db.Customers.Remove(customer);
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
