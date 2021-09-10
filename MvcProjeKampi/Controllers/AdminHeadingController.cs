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
    public class AdminHeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingValidator headingValidator = new HeadingValidator();

        public AdminHeadingController()
        {
            var categoryValues = categoryManager.List();
            var writerValues = writerManager.List();
            List<SelectListItem> CategoryNames = categoryValues.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();
            List<SelectListItem> WriterNames = writerValues.Select(w => new SelectListItem
            {
                Text = w.WriterName + " " + w.WriterSurname,
                Value = w.WriterId.ToString()
            }).ToList();
            ViewBag.CategoryNames = CategoryNames;
            ViewBag.WriterNames = WriterNames;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var headingValues = headingManager.List();
            return View(headingValues);
        }

        public ActionResult HeadingByWriter(int id)
        {
            var headingValues = headingManager.ListByWriter(id);
            return PartialView("HeadingFilteredPartial", headingValues);
        }

        [HttpGet]
        public ActionResult HeadingInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HeadingInsert(Heading p)
        {
            ValidationResult results = headingValidator.Validate(p);
            if (results.IsValid)
            {
                p.HeadingCreatedOn = DateTime.Parse(DateTime.Now.ToShortDateString());
                headingManager.Insert(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult HeadingUpdate(int id)
        {
            var headingValues = headingManager.GetById(id);
            return View(headingValues);
        }

        [HttpPost]
        public ActionResult HeadingUpdate(Heading p)
        {
            ValidationResult results = headingValidator.Validate(p);
            if (results.IsValid)
            {
                headingManager.Update(p);
                return RedirectToAction("Index");
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

        public ActionResult HeadingDelete(int id)
        {
            var headingValues = headingManager.GetById(id);
            headingValues.HeadingStatus = !headingValues.HeadingStatus;
            headingManager.Update(headingValues);
            return RedirectToAction("Index");
        }
    }
}
