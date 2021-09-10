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
    [Authorize]
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();

        public ActionResult Index()
        {
            var categoryValues = categoryManager.List();
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
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.Insert(p);
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
            var categoryValues = categoryManager.GetById(id);
            categoryValues.CategoryStatus = !categoryValues.CategoryStatus;
            categoryManager.Update(categoryValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            var categoryValues = categoryManager.GetById(id);
            return View(categoryValues);
        }

        [HttpPost]
        public ActionResult CategoryUpdate(Category p)
        {
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.Update(p);
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
    }
}
