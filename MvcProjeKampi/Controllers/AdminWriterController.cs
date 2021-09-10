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
    public class AdminWriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        [AllowAnonymous]
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
            var writerValues = writerManager.List();
            if (writerValues.Select(w => w.WriterEmailAddress).Contains(p.WriterEmailAddress))
            {
                ModelState.AddModelError(nameof(p.WriterEmailAddress), "Eposta adresi kayıtlı");
            }
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                WebImage photo = WebImage.GetImageFromRequest();
                if (photo != null)
                {
                    string avatarWriterPath = "/images/avatar/writer/";
                    string newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);

                    p.WriterProfilePicture = avatarWriterPath + newFileName;
                    photo.Resize(width: 64, height: 64, preserveAspectRatio: false, preventEnlarge: true);
                    photo.Save("~" + p.WriterProfilePicture);

                    writerManager.Insert(p);
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
                WebImage photo = WebImage.GetImageFromRequest();
                if (photo != null)
                {
                    string avatarWriterPath = "/images/avatar/writer/";
                    string newFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photo.FileName);

                    p.WriterProfilePicture = avatarWriterPath + newFileName;
                    photo.Resize(width: 64, height: 64, preserveAspectRatio: false, preventEnlarge: true);
                    photo.Save("~" + p.WriterProfilePicture);

                    writerManager.Update(p);
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

        public ActionResult WriterDelete(int id)
        {
            var writerValues = writerManager.GetById(id);
            writerValues.WriterStatus = !writerValues.WriterStatus;
            writerManager.Update(writerValues);
            return RedirectToAction("Index");
        }
    }
}
