using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        PersonaSkillManager personaSkillManager = new PersonaSkillManager(new EfPersonaSkillDal());
        public ActionResult Index()
        {
            var personaSkillValues = personaSkillManager.ListByPersona(1);
            return View(personaSkillValues);
        }

        public ActionResult Hash(string data = null)
        {
            if (data != null)
            {
                ViewBag.SHA1 = HashManager.SHA1(data);
                ViewBag.MD5 = HashManager.MD5(data);
                ViewBag.Hash = true;
            }
            return View();
        }
    }
}
