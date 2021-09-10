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
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class PanelController : Controller
    {
        PanelAdminManager panelAdminManager = new PanelAdminManager(new EfAdminDal());
        PanelWriterManager panelWriterManager = new PanelWriterManager(new EfWriterDal());
        PanelAdminValidator panelAdminValidator = new PanelAdminValidator();
        PanelWriterValidator panelWriterValidator = new PanelWriterValidator();

        public ActionResult Index()
        {
            if (Session["AdminUsername"] != null)
            {
                return RedirectToAction("Index", "AdminHome");
            }
            else if (Session["WriterEmailAddress"] != null)
            {
                return RedirectToAction("Index", "WriterHome");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin p)
        {
            var loginValues = panelAdminManager.Auth(p.AdminUsername, p.AdminPassword);
            ValidationResult results = panelAdminValidator.Validate(p);
            if (results.IsValid)
            {
                if (loginValues != null)
                {
                    FormsAuthentication.SetAuthCookie(loginValues.AdminUsername, false);
                    Session["AdminUsername"] = loginValues.AdminUsername;
                    Session["AdminRoleCode"] = loginValues.AdminRoleCode;
                    //string returnUrl = Request.QueryString["ReturnUrl"].ToString();
                    //if (!String.IsNullOrEmpty(returnUrl)) return Redirect(Server.UrlEncode(returnUrl));
                    return RedirectToAction("Index", "AdminHome");
                }
                ModelState.AddModelError(nameof(loginValues.AdminPassword), "Kullanıcı adı ve parola eşleşmiyor");
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
        public ActionResult Writer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Writer(Writer p)
        {
            var loginValues = panelWriterManager.Auth(p.WriterEmailAddress, p.WriterPassword);
            ValidationResult results = panelWriterValidator.Validate(p);
            if (results.IsValid)
            {
                if (loginValues != null)
                {
                    FormsAuthentication.SetAuthCookie(loginValues.WriterEmailAddress, false);
                    Session["WriterEmailAddress"] = loginValues.WriterEmailAddress;
                    Session["WriterName"] = loginValues.WriterName;
                    Session["WriterProfilePicture"] = loginValues.WriterProfilePicture;
                    //string returnUrl = Request.QueryString["ReturnUrl"].ToString();
                    //if (!String.IsNullOrEmpty(returnUrl)) return Redirect(Server.UrlEncode(returnUrl));
                    return RedirectToAction("Index", "WriterHome");
                }
                ModelState.AddModelError(nameof(loginValues.WriterPassword), "Kullanıcı adı ve parola eşleşmiyor");
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

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
