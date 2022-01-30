using SpaLNT.Models;
using SpaLNT.Models.Spa;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class ProductImportController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        [HttpGet]
        public ActionResult CreateOrderProvider()
        {
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrderProvider([Bind(Include = "ProviderId,Discount,Note")] OrderProvider orderProvider)
        {
            if (ModelState.IsValid)
            {
                orderProvider.Date = DateTime.Now.ToString();

                TempData["OrderProvider"] = orderProvider;

                return RedirectToAction("CreateOrderImport");
            }
            return View(orderProvider);
        }

        [HttpGet]
        public async Task<ActionResult> CreateOrderImport()
        {
            dynamic model = new ExpandoObject();

            var orderProvider = (OrderProvider)TempData["OrderProvider"];

            TempData["Products"] = await GetAllProduct();

            var provider = db.Providers.Find(1);

            var cart = Session["CartSession"];
            var listProduct = new List<CartItem>();

            if (orderProvider != null && cart != null)
            {
                listProduct = (List<CartItem>)cart;
            }

            model.OrderProvider = orderProvider;
            model.Provider = provider;
            model.ListProduct = listProduct;

            return View(model);

        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await db.Products.ToListAsync();
        }

        [HttpPost]
        public JsonResult QueryProduct(string Prefix)
        {
            string prefix = Prefix.ToUpper().Trim();

            List<Product> products = (List<Product>)TempData["Products"];
            TempData.Keep("Products");

            var Name = products.Where(x => x.Name.ToUpper().Contains(prefix) || x.ProductCode.ToUpper().Contains(prefix))
                .Select(x => new { x.ProductCode, x.Name, x.ImgAvatar });

            return Json(Name, JsonRequestBehavior.AllowGet);
        }

    }
}