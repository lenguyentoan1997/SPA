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
using System.Text.RegularExpressions;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        // GET: Admin/Products
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10)
        {
            var products = db.Products.Include(p => p.Factory).Include(p => p.Provider).Include(p => p.Type);
            var listProduct = await products.ToListAsync();

            return View(listProduct.ToPagedList(page, pageSize));
        }

        // GET: Admin/Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.FactoryId = new SelectList(db.Factories, "Id", "Name");
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,TypeId,FactoryId,ProviderId,ImportPrice,ExportPrice,ProductCode,Discount,ImgAvatar,Thumbnail1,Thumbnail2,Thumbnail3")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(product.ImgAvatar))
                {
                    product.ImgAvatar = "defaultAvaProduct.jpg";
                }
                else
                {
                    product.ImgAvatar = SaveImgInProject(product.Name, "Avatar", 0);
                }

                if (string.IsNullOrEmpty(product.Thumbnail1))
                {
                    product.Thumbnail1 = "defaultAvaProduct.jpg";
                }
                else
                {
                    product.Thumbnail1 = SaveImgInProject(product.Name, "Thumbnail1", 1);
                }

                if (string.IsNullOrEmpty(product.Thumbnail2))
                {
                    product.Thumbnail2 = "defaultAvaProduct.jpg";
                }
                else
                {
                    product.Thumbnail2 = SaveImgInProject(product.Name, "Thumbnail2", 2);
                }

                if (string.IsNullOrEmpty(product.Thumbnail3))
                {
                    product.Thumbnail3 = "defaultAvaProduct.jpg";
                }
                else
                {
                    product.Thumbnail3 = SaveImgInProject(product.Name, "Thumbnail3", 3);
                }

                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FactoryId = new SelectList(db.Factories, "Id", "Name", product.FactoryId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name", product.ProviderId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactoryId = new SelectList(db.Factories, "Id", "Name", product.FactoryId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name", product.ProviderId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);

            List<string> imgList = new List<string>()
            {
                product.ImgAvatar,
                product.Thumbnail1,
                product.Thumbnail2,
                product.Thumbnail3
            };

            TempData["productImg"] = imgList;

            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,TypeId,FactoryId,ProviderId,ImportPrice,ExportPrice,ProductCode,Discount,ImgAvatar,Thumbnail1,Thumbnail2,Thumbnail3")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;

                List<string> imgList = (List<string>)TempData["productImg"];

                if (string.IsNullOrEmpty(product.ImgAvatar))
                {
                    product.ImgAvatar = imgList[0];
                }
                else
                {
                    product.ImgAvatar = SaveImgInProject(product.Name, "Avatar", 0);
                }

                if (string.IsNullOrEmpty(product.Thumbnail1))
                {
                    product.Thumbnail1 = imgList[1];
                }
                else
                {
                    product.Thumbnail1 = SaveImgInProject(product.Name, "Thumbnail1", 1);
                }

                if (string.IsNullOrEmpty(product.Thumbnail2))
                {
                    product.Thumbnail2 = imgList[2];
                }
                else
                {
                    product.Thumbnail2 = SaveImgInProject(product.Name, "Thumbnail2", 2);
                }

                if (string.IsNullOrEmpty(product.Thumbnail3))
                {
                    product.Thumbnail3 = imgList[3];
                }
                else
                {
                    product.Thumbnail3 = SaveImgInProject(product.Name, "Thumbnail3", 3);
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FactoryId = new SelectList(db.Factories, "Id", "Name", product.FactoryId);
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name", product.ProviderId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", product.TypeId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //
        public string SaveImgInProject(string name, string type = null, int number = 0)
        {
            string dateTime = DateTime.Now.ToString();
            string avatarName = name + dateTime + type + ".png";
            //remove characters in avatarName
            string avatarNameFormat = Regex.Replace(avatarName, "[:/ ]", "");

            //Copy img in project
            if (HttpContext.Request.Files[number].ContentLength != 0)
            {
                var httpContextRequestFile = HttpContext.Request.Files[number];
                string fullPathWithFileName = "~/Areas/Admin/Content/img/Product/" + avatarNameFormat;
                httpContextRequestFile.SaveAs(Server.MapPath(fullPathWithFileName));
            }

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
