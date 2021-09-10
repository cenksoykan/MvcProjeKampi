using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class AdminGalleryImageController : Controller
    {
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
                WebImage photo = WebImage.GetImageFromRequest();
                if (photo != null)
                {
                    string galleryPath = "/images/gallery/";
                    string newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);

                    p.GalleryImagePath = galleryPath + newFileName;
                    photo.Resize(width: 1920, height: 1920, preserveAspectRatio: true, preventEnlarge: true);
                    photo.Save("~" + p.GalleryImagePath);

                    p.GalleryImageThumbPath = galleryPath + "thumbs/" + newFileName;
                    photo.Resize(width: 400, height: 400, preserveAspectRatio: true, preventEnlarge: true);
                    photo.Save("~" + p.GalleryImageThumbPath);

                    galleryImageManager.Insert(p);

                    return RedirectToAction("Index");
                }
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
                WebImage photo = WebImage.GetImageFromRequest();
                if (photo != null)
                {
                    string galleryPath = "/images/gallery/";
                    string newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);

                    p.GalleryImagePath = galleryPath + newFileName;
                    photo.Resize(width: 1920, height: 1920, preserveAspectRatio: true, preventEnlarge: true);
                    photo.Save("~" + p.GalleryImagePath);

                    p.GalleryImageThumbPath = galleryPath + "thumbs/" + newFileName;
                    photo.Resize(width: 400, height: 400, preserveAspectRatio: true, preventEnlarge: true);
                    photo.Save("~" + p.GalleryImageThumbPath);

                    galleryImageManager.Update(p);

                    return RedirectToAction("Index");
                }
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
            galleryImageValues.GalleryImageStatus = !galleryImageValues.GalleryImageStatus;
            galleryImageManager.Update(galleryImageValues);
            return RedirectToAction("Index");
        }
    }
}
