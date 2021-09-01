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
    public class AdminAboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        AboutValidator aboutValidator = new AboutValidator();
        public ActionResult Index()
        {
            var aboutValues = aboutManager.List();
            return View(aboutValues);
        }

        [HttpPost]
        public ActionResult AboutInsert(About p)
        {
            ValidationResult results = aboutValidator.Validate(p);
            if (results.IsValid)
            {
                aboutManager.Insert(p);
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

        public PartialViewResult AboutModalPartial ()
        {
            return PartialView();
        }
    }
}