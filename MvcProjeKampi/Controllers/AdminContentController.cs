using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class AdminContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        [AllowAnonymous]
        public ActionResult Index(string q)
        {
            var contentValues = contentManager.List(q);
            return View(contentValues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.ListByHeading(id);
            return PartialView("ContentFilteredPartial", contentValues);
        }

        public ActionResult ContentByWriter(int id)
        {
            var contentValues = contentManager.ListByWriter(id);
            ViewBag.Subtitle = true;
            return PartialView("ContentFilteredPartial", contentValues);
        }
    }
}
