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
    public class WriterHeadingController : Controller
    {
        PanelWriterManager panelWriterManager = new PanelWriterManager(new EfWriterDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingValidator headingValidator = new HeadingValidator();

        int sessionUserId;

        public WriterHeadingController()
        {
            sessionUserId = panelWriterManager.SessionWriterId();
            var categoryValues = categoryManager.List();
            List<SelectListItem> CategoryNames = categoryValues.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();
            ViewBag.CategoryNames = CategoryNames;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var headingValues = headingManager.ListByWriter(sessionUserId);
            return View(headingValues);
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
                p.WriterId = sessionUserId;
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

        public PartialViewResult HeadingListActivePartial()
        {
            var headingValues = headingManager.ListByWriter(sessionUserId).Where(h => h.HeadingStatus).ToList();
            return PartialView("HeadingListPartial", headingValues);
        }

        public PartialViewResult HeadingListPassivePartial()
        {
            var headingValues = headingManager.ListByWriter(sessionUserId).Where(h => !h.HeadingStatus).ToList();
            return PartialView("HeadingListPartial", headingValues);
        }
    }
}
