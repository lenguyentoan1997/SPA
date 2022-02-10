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
using System.Dynamic;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class OrderProvidersController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        // GET: Admin/OrderProviders
        public async Task<ActionResult> Index()
        {
            var orderProviders = db.OrderProviders.Include(o => o.Branch).Include(o => o.Provider);
            return View(await orderProviders.ToListAsync());
        }

        // GET: Admin/OrderProviders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProvider orderProvider = await db.OrderProviders.FindAsync(id);
            if (orderProvider == null)
            {
                return HttpNotFound();
            }
            return View(orderProvider);
        }

        // GET: Admin/OrderProviders/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            dynamic model = new ExpandoObject();

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            model.Providers = await db.Providers.ToListAsync();
            model.Products = await db.Products.ToListAsync();
            return View(model);
        }

        // POST: Admin/OrderProviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Date,Paid,Debt,Note,ProviderId,BranchId,Discount,Total")] OrderProvider orderProvider)
        {
            if (ModelState.IsValid)
            {
                db.OrderProviders.Add(orderProvider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", orderProvider.BranchId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name", orderProvider.ProviderId);
            return View(orderProvider);
        }

        // GET: Admin/OrderProviders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProvider orderProvider = await db.OrderProviders.FindAsync(id);
            if (orderProvider == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", orderProvider.BranchId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name", orderProvider.ProviderId);
            return View(orderProvider);
        }

        // POST: Admin/OrderProviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Date,Paid,Debt,Note,ProviderId,BranchId,Discount,Total")] OrderProvider orderProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderProvider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", orderProvider.BranchId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name", orderProvider.ProviderId);
            return View(orderProvider);
        }

        // GET: Admin/OrderProviders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderProvider orderProvider = await db.OrderProviders.FindAsync(id);
            if (orderProvider == null)
            {
                return HttpNotFound();
            }
            return View(orderProvider);
        }

        // POST: Admin/OrderProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderProvider orderProvider = await db.OrderProviders.FindAsync(id);
            db.OrderProviders.Remove(orderProvider);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
