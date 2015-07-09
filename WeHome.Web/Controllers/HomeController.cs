using System.Web.Mvc;

namespace WeHome.Web.Controllers
{

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Route("user/images")]
        public ActionResult UserImages()
        {
            return View();
        }

    }
}