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
    public class AdminGalleryImageController : Controller
    {
        // GET: AdminGalleryImage
        GalleryImageManager galleryImageManager = new GalleryImageManager(new EfGalleryImageDal());
        GalleryImageValidator galleryImageValidator = new GalleryImageValidator();
        public ActionResult Index()
        {
            var galleryImageValues = galleryImageManager.List();
            return View(galleryImageValues);
        }

        [HttpGet]
        public ActionResult GalleryImageInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GalleryImageInsert(GalleryImage p)
        {
            ValidationResult results = galleryImageValidator.Validate(p);
            if (results.IsValid)
            {
                galleryImageManager.Insert(p);
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
        public ActionResult GalleryImageUpdate(int id)
        {
            var galleryImageValues = galleryImageManager.GetById(id);
            return View(galleryImageValues);
        }

        [HttpPost]
        public ActionResult GalleryImageUpdate(GalleryImage p)
        {
            ValidationResult results = galleryImageValidator.Validate(p);
            if (results.IsValid)
            {
                galleryImageManager.Update(p);
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

        public ActionResult GalleryImageDelete(int id)
        {
            var galleryImageValues = galleryImageManager.GetById(id);
            galleryImageManager.Update(galleryImageValues);
            return RedirectToAction("Index");
        }
    }
}