using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "AdminStatistic");
        }
    }
}
