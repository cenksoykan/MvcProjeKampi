using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminAuthorizationController : Controller
    {
        // GET: AdminAuthorization
        public ActionResult Index()
        {
            return View();
        }
    }
}