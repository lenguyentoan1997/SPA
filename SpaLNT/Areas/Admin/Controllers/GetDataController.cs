using SpaLNT.Models.Spa;
using System.Linq;
using System.Web.Mvc;
using X.PagedList;

namespace SpaLNT.Areas.Admin.Controllers
{
    public class GetDataController : Controller
    {
        private SpaDbContext db = new SpaDbContext();

        public ActionResult GetProviders()
        {
            return View(db.Providers.ToList());
        }
    }
}