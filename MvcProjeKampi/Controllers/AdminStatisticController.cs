using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminStatisticController : Controller
    {
        // GET: AdminStatistic
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public ActionResult Index()
        {
            var categoryValues = categoryManager.List();
            var writerValues = writerManager.List();
            var headingValues = headingManager.List();
            StatisticModel statisticModel = new StatisticModel
            {
                CategoryCount = categoryValues.Count(),
                HeadingCountSoftware = headingValues.Count(h => h.CategoryId == 13),
                WriterCountFiltered = writerValues.Count(w => w.WriterName.ToUpper().Contains("A")),
                CategoryTopHeading = categoryValues.Where(
                    c => c.CategoryId == headingValues
                        .GroupBy(h => h.CategoryId)
                        .OrderByDescending(h => h.Count())
                        .Select(h => h.Key)
                        .FirstOrDefault()
                ).Select(c => c.CategoryName).FirstOrDefault(),
                CategoryStatusDiff = Math.Abs(categoryValues.Count(c => c.CategoryStatus) - categoryValues.Count(c => !c.CategoryStatus))
            };
            return View(statisticModel);
        }
    }
}