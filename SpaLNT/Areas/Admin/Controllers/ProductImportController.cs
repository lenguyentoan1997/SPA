using SpaLNT.Models.Spa;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace SpaLNT.Areas.Admin.Controllers
{
    public class ProductImportController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        [HttpGet]
        public async Task<ActionResult> CreateOrderImport()
        {
            dynamic model = new ExpandoObject();

            ViewBag.BranchId = new SelectList(db.Branches,"Id","BranchName");
            model.Providers = await db.Providers.ToListAsync();
            model.Products = await db.Products.ToListAsync();

            return View(model);
        }
    }
}