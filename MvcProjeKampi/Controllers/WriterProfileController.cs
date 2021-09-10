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
    public class WriterProfileController : Controller
    {
        PanelWriterManager panelWriterManager = new PanelWriterManager(new EfWriterDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        int sessionUserId;

        public WriterProfileController()
        {
            sessionUserId = panelWriterManager.SessionWriterId();
        }

        public ActionResult Index()
        {
            var writerValues = writerManager.GetById(sessionUserId);
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult WriterUpdate()
        {
            var writerValues = writerManager.GetById(sessionUserId);
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
    }
}
