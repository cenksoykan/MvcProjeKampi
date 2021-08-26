using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValues = cm.List();
            return View(categoryValues);
            //return View();
        }
        public ActionResult CategoryList()
        {
            var categoryValues = cm.List();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult CategoryInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryInsert(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                cm.Insert(p);
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            var categoryValues = cm.GetById(id);
            cm.Delete(categoryValues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categoryValues = cm.GetById(id);
            return View(categoryValues);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            cm.Update(p);
            return RedirectToAction("Index");
        }
    }
}