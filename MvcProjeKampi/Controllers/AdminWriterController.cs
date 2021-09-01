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
    public class AdminWriterController : Controller
    {
        // GET: AdminWriter
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writerValues = writerManager.List();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult WriterInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterInsert(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writerManager.Insert(p);
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
        public ActionResult WriterUpdate(int id)
        {
            var writerValues = writerManager.GetById(id);
            return View(writerValues);
        }

        [HttpPost]
        public ActionResult WriterUpdate(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                writerManager.Update(p);
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

        public ActionResult WriterDelete(int id)
        {
            var writerValues = writerManager.GetById(id);
            writerValues.WriterStatus = !writerValues.WriterStatus;
            writerManager.Update(writerValues);
            return RedirectToAction("Index");
        }
    }
}