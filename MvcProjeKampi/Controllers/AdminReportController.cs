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
    public class AdminReportController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult ReportHeading()
        {
            var headingValues = headingManager.List();
            return View(headingValues);
        }

        public ActionResult ReportCategory()
        {
            var categoryValues = categoryManager.List();
            return View(categoryValues);
        }

        public ActionResult ReportWriting()
        {
            var writerValues = writerManager.List();
            return View(writerValues);
        }
    }
}
