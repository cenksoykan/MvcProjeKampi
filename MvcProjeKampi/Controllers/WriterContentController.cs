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
    public class WriterContentController : Controller
    {
        PanelWriterManager panelWriterManager = new PanelWriterManager(new EfWriterDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentValidator contentValidator = new ContentValidator();

        int sessionUserId;

        public WriterContentController()
        {
            sessionUserId = panelWriterManager.SessionWriterId();
        }

        [AllowAnonymous]
        public ActionResult Index(string q)
        {
            var contentValues = contentManager.ListByWriter(sessionUserId, q);
            return View(contentValues);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.ListByWriter(id).Where(w => w.ContentStatus).ToList();
            return PartialView("ContentFilteredPartial", contentValues);
        }

        public ActionResult ContentByWriter(int id)
        {
            var contentValues = contentManager.ListByWriter(id).Where(w => w.ContentStatus).ToList();
            ViewBag.Subtitle = true;
            return PartialView("ContentFilteredPartial", contentValues);
        }

        [HttpGet]
        public ActionResult ContentInsert(int id)
        {
            var headingValues = headingManager.List().Where(h => h.HeadingId == id && h.HeadingStatus).FirstOrDefault();
            if (headingValues == null) return RedirectToAction("Index");
            ViewBag.HeadingId = id;
            ViewBag.HeadingName = headingValues.HeadingName;
            return View();
        }

        [HttpPost]
        public ActionResult ContentInsert(Content p)
        {
            ValidationResult results = contentValidator.Validate(p);
            if (results.IsValid)
            {
                p.ContentCreatedOn = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = sessionUserId;
                contentManager.Insert(p);
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
        public ActionResult ContentUpdate(int id)
        {
            var contentValues = contentManager.GetById(id);
            return View(contentValues);
        }

        [HttpPost]
        public ActionResult ContentUpdate(Content p)
        {
            ValidationResult results = contentValidator.Validate(p);
            if (results.IsValid)
            {
                contentManager.Update(p);
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

        public ActionResult ContentDelete(int id)
        {
            var contentValues = contentManager.GetById(id);
            contentValues.ContentStatus = !contentValues.ContentStatus;
            contentManager.Update(contentValues);
            return RedirectToAction("Index");
        }
    }
}
