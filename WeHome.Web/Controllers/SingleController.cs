using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeHome.Web.Controllers
{
    [Authorize]
    public class SingleController : Controller
    {
        // GET: Single
        public ActionResult Index()
        {
            ViewBag.Account = HttpContext.User.Identity.Name;
            return View();
        }

        [Route("user/videos")]
        public ActionResult Video()
        {
            return View();
        }

        [Route("admin/space")]
        public ActionResult MySpace()
        {
            return View();
        }

        [Route("user/question")]
        public ActionResult Question()
        {
            return View();
        }
    }
}