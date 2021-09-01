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
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        LoginManager loginManager = new LoginManager(new EfLoginDal());
        LoginValidator loginValidator = new LoginValidator();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var loginValues = loginManager.Auth(p.AdminUsername, p.AdminPassword);
            ValidationResult results = loginValidator.Validate(p);
            if (results.IsValid)
            {
                if (loginValues != null)
                {
                    FormsAuthentication.SetAuthCookie(loginValues.AdminUsername, false);
                    Session["AdminUsername"] = loginValues.AdminUsername;
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
    }
}