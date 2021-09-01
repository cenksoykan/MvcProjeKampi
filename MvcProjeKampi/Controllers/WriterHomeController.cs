using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterHomeController : Controller
    {
        // GET: WriterHome
        public ActionResult Index()
        {
            return RedirectToAction("Index", "WriterProfile");
        }
    }
}