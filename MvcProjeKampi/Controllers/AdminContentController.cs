using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContentController : Controller
    {
        // GET: AdminContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            var contentValues = contentManager.List();
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