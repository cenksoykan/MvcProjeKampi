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
    [Authorize]
    public class AdminChartController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult ChartCategory()
        {
            return View();
        }

        public ActionResult ChartHeading()
        {
            return View();
        }

        public JsonResult JsonCategory()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonHeading()
        {
            return Json(HeadingList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryModel> CategoryList()
        {
            var categoryValues = categoryManager.List();
            var headingValues = headingManager.List();

            List<CategoryModel> categoryList = new List<CategoryModel>();
            
            foreach (var item in categoryValues)
            {
                categoryList.Add(new CategoryModel() {
                    CategoryName = item.CategoryName,
                    CategoryCount = headingValues.Count(x => x.Category.CategoryName == item.CategoryName)
                });
            }
            
            return categoryList;
        }

        public List<HeadingModel> HeadingList()
        {
            var headingValues = headingManager.List();
            var contentValues = contentManager.List();
            var contentTopHeading = contentValues.GroupBy(c => c.HeadingId).OrderBy(c => c.Count()).Select(c => c.Key).Take(10).ToList();

            List<HeadingModel> headingList = new List<HeadingModel>();

            foreach (var item in contentTopHeading)
            {
                headingList.Add(new HeadingModel()
                {
                    HeadingName = headingValues.Where(h => h.HeadingId == item).Select(h => h.HeadingName).FirstOrDefault(),
                    ContentCountActive = contentValues.Count(c => c.HeadingId == item && c.ContentStatus),
                    ContentCountPassive = contentValues.Count(c => c.HeadingId == item && !c.ContentStatus)
                });
            }

            return headingList;
        }
    }
}
