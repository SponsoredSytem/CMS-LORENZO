using System.Web.Mvc;

namespace TMD.Web.Controllers
{
    public class CompanyController : Controller
    {
        public CompanyController()
        {
            
        }
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
    }
}