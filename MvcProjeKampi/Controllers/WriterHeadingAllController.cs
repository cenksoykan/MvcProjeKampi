using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class WriterHeadingAllController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());

        public ActionResult Index(int page = 1)
        {
            var headingValues = headingManager.List().Where(h => h.HeadingStatus).ToPagedList(page, 4);
            return PartialView(headingValues);
        }
    }
}
