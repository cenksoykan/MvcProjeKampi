using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class AdminMessageController : Controller
    {
        // GET: AdminMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Index()
        {
            return RedirectToAction("MessageInbox");
        }

        [HttpPost]
        public ActionResult MessageInsert(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.Insert(p);
                return RedirectToAction("MessageSent");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("MessageSent");
        }

        public ActionResult MessageInbox()
        {
            var messageValues = messageManager.ListInbox("admin");
            ViewBag.Title = "Gelen kutusu";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageSent()
        {
            var messageValues = messageManager.ListSent("admin");
            ViewBag.Title = "Gönderilmiş iletiler";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageDraft()
        {
            var messageValues = messageManager.ListSent("admin", false);
            ViewBag.Title = "Taslaklar";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageSpam()
        {
            var messageValues = messageManager.ListInbox("admin", false);
            ViewBag.Title = "Spam";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageTrash()
        {
            var messageValues = messageManager.List("admin", false);
            ViewBag.Title = "Çöp kutusu";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            bool isSender = messageValues.MessageReceiver == "admin";
            ContactDetailModel contactDetailModel = new ContactDetailModel
            {
                Subject = messageValues.MessageSubject,
                //User = null,
                Sender =  isSender ? messageValues.MessageSender : null,
                Receiver =  isSender ? null : messageValues.MessageReceiver,
                Date = messageValues.MessageDate,
                Body = messageValues.MessageBody
            };
            messageValues.MessageStatusRead = true;
            messageManager.Update(messageValues);
            if (String.IsNullOrEmpty(messageValues.MessageFolder))
            {
                ViewBag.Title = isSender ? "Gelen kutusu" : "Gönderilmiş iletiler";
                ViewBag.ActionName = isSender ? "MessageInbox" : "MessageSent";
            }
            else if (messageValues.MessageFolder == "DRAFT")
            {
                ViewBag.Title = "Taslaklar";
                ViewBag.ActionName = "MessageDraft";
            }
            else if (messageValues.MessageFolder == "TRASH")
            {
                ViewBag.Title = "Çöp kutusu";
                ViewBag.ActionName = "MessageTrash";
            }
            return View(contactDetailModel);
        }

        public PartialViewResult MessageNewPartial()
        {
            return PartialView();
        }
    }
}