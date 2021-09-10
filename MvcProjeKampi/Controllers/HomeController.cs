using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        GalleryImageManager galleryImageManager = new GalleryImageManager(new EfGalleryImageDal());

        public HomeController()
        {
            ViewBag.AppName = "MVC Proje Kampı";
        }

        public ActionResult Index()
        {
            var galleryImageValues = galleryImageManager.List().Where(g => g.GalleryImageStatus).ToList();
            return View(galleryImageValues);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Content(int id = -1)
        {
            var headingValues = contentManager.List()
                .Where(c => c.ContentStatus && c.Heading.HeadingStatus)
                .Select(x => x.Heading)
                .OrderBy(x => Guid.NewGuid())
                .ToList();
            if (id == -1) return RedirectToAction(String.Format("Content/{0}", headingValues?.Select(h => h.HeadingId).FirstOrDefault() ?? 0));
            return View(headingValues);
        }

        public PartialViewResult ContentByHeadingPartial(int id = 0)
        {
            var contentValues = contentManager.ListByHeading(id).Where(w => w.ContentStatus).ToList();
            return PartialView(contentValues);
        }
    }
}
