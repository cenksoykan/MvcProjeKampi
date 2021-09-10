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
    public class AdminAuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminRoleManager adminRoleManager = new AdminRoleManager(new EfAdminRoleDal());
        AdminValidator adminValidator = new AdminValidator();

        public AdminAuthorizationController()
        {
            var adminRoleValues = adminRoleManager.List();
            List<SelectListItem> AdminRoles = adminRoleValues.Select(a => new SelectListItem
            {
                Text = a.AdminRoleCode,
                Value = a.AdminRoleCode
            }).ToList();
            ViewBag.AdminRoles = AdminRoles;
        }

        public ActionResult Index()
        {
            var adminValues = adminManager.List();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AdminInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminInsert(Admin p)
        {
            var adminValues = adminManager.List();
            if (adminValues.Select(w => w.AdminUsername).Contains(p.AdminUsername))
            {
                ModelState.AddModelError(nameof(p.AdminUsername), "Kullanıcı adı kayıtlı");
            }
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                adminManager.Insert(p);
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
        public ActionResult AdminUpdate(int id)
        {
            var adminValues = adminManager.GetById(id);
            if (adminValues.AdminRoleCode == "S") return RedirectToAction("Index");
            return View(adminValues);
        }

        [HttpPost]
        public ActionResult AdminUpdate(Admin p)
        {
            ValidationResult results = adminValidator.Validate(p);
            if (results.IsValid)
            {
                adminManager.Update(p);
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
    }
}
