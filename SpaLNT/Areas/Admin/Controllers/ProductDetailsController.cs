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

namespace SpaLNT.Areas.Admin.Controllers
{
    public class ProductDetailsController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        // GET: Admin/ProductDetails
        public async Task<ActionResult> Index()
        {
            var productDetails = db.ProductDetails.Include(p => p.Branch).Include(p => p.Product);
            return View(await productDetails.ToListAsync());
        }

        // GET: Admin/ProductDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Quantity,ProductId,BranchId")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.ProductDetails.Add(productDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", productDetail.BranchId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", productDetail.BranchId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productDetail.ProductId);
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Quantity,ProductId,BranchId")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDetail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.Branches, "Id", "BranchName", productDetail.BranchId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productDetail.ProductId);
            return View(productDetail);
        }

        // GET: Admin/ProductDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return HttpNotFound();
            }
            return View(productDetail);
        }

        // POST: Admin/ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            db.ProductDetails.Remove(productDetail);
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
