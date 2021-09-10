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
        PanelAdminManager panelAdminManager = new PanelAdminManager(new EfAdminDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageValidator messageValidator = new MessageValidator();

        string sessionUser;

        public AdminMessageController()
        {
            sessionUser = panelAdminManager.SessionAdmin();
        }

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
                p.MessageSender = sessionUser;
                p.MessageBody = Server.HtmlEncode(p.MessageBody);
                messageManager.Insert(p);
                return RedirectToAction("MessageSent");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return Json(results, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "S,A")]
        public ActionResult MessageContact(string q)
        {
            var contactValues = contactManager.List(q);
            ViewBag.Title = "İletişim";
            return View(contactValues);
        }

        public ActionResult MessageInbox(string q)
        {
            var messageValues = messageManager.ListInbox(sessionUser, q);
            ViewBag.Title = "Gelen kutusu";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageSent(string q)
        {
            var messageValues = messageManager.ListSent(sessionUser, q);
            ViewBag.Title = "Gönderilmiş iletiler";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageDraft(string q)
        {
            var messageValues = messageManager.ListSent(sessionUser, q, false);
            ViewBag.Title = "Taslaklar";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageSpam(string q)
        {
            var messageValues = messageManager.ListInbox(sessionUser, q, false);
            ViewBag.Title = "Spam";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageTrash(string q)
        {
            var messageValues = messageManager.List(sessionUser, q, false);
            ViewBag.Title = "Çöp kutusu";
            return PartialView("MessageBoxPartial", messageValues);
        }

        public ActionResult MessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            bool isSender = messageValues.MessageSender == sessionUser;
            bool isReceiver = messageValues.MessageReceiver == sessionUser;
            ContactDetailModel contactDetailModel = new ContactDetailModel
            {
                Subject = messageValues.MessageSubject,
                //User = null,
                Sender = isReceiver ? messageValues.MessageSender : null,
                Receiver = isSender ? messageValues.MessageReceiver : null,
                Date = messageValues.MessageDate,
                Body = Server.HtmlDecode(messageValues.MessageBody)
            };
            if (isSender) messageValues.MessageSenderStatusRead = true;
            if (isReceiver) messageValues.MessageReceiverStatusRead = true;
            messageManager.Update(messageValues);
            if (String.IsNullOrEmpty(messageValues.MessageReceiverFolder))
            {
                ViewBag.Title = isReceiver ? "Gelen kutusu" : "Gönderilmiş iletiler";
                ViewBag.ActionName = isReceiver ? "MessageInbox" : "MessageSent";
            }
            else if (messageValues.MessageReceiverFolder == "DRAFT")
            {
                ViewBag.Title = "Taslaklar";
                ViewBag.ActionName = "MessageDraft";
            }
            else if (messageValues.MessageReceiverFolder == "TRASH")
            {
                ViewBag.Title = "Çöp kutusu";
                ViewBag.ActionName = "MessageTrash";
            }
            return View(contactDetailModel);
        }

        public ActionResult MessageMarkRead(int id)
        {
            var messageValues = messageManager.GetById(id);
            bool isSender = messageValues.MessageSender == sessionUser;
            bool isReceiver = messageValues.MessageReceiver == sessionUser;
            if (isSender) messageValues.MessageSenderStatusRead = !messageValues.MessageSenderStatusRead;
            if (isReceiver) messageValues.MessageReceiverStatusRead = !messageValues.MessageReceiverStatusRead;
            messageManager.Update(messageValues);
            return RedirectToAction("MessageTrash");
        }

        public ActionResult MessageDelete(int id)
        {
            var messageValues = messageManager.GetById(id);
            bool isSender = messageValues.MessageSender == sessionUser;
            bool isReceiver = messageValues.MessageReceiver == sessionUser;
            if (isSender)
            {
                bool isTrash = messageValues.MessageSenderFolder == "TRASH";
                messageValues.MessageSenderFolder = isTrash ? ".LOG" : "TRASH";
            }
            if (isReceiver)
            {
                bool isTrash = messageValues.MessageReceiverFolder == "TRASH";
                messageValues.MessageReceiverFolder = isTrash ? ".LOG" : "TRASH";
            }
            messageManager.Update(messageValues);
            return RedirectToAction("MessageTrash");
        }

        public ActionResult MessageContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            ContactDetailModel contactDetailModel = new ContactDetailModel
            {
                Subject = contactValues.ContactSubject,
                User = contactValues.ContactUserName,
                Sender = contactValues.ContactEmailAddress,
                //Receiver = "",
                Date = contactValues.ContactDate,
                Body = contactValues.ContactMessage
            };
            contactValues.ContactStatusRead = true;
            contactManager.Update(contactValues);
            ViewBag.Title = "İletişim";
            ViewBag.ActionName = "MessageContact";
            return View("MessageDetails", contactDetailModel);
        }

        public PartialViewResult MessageNewPartial()
        {
            return PartialView();
        }

        public PartialViewResult MessageNavPartial()
        {
            var contactValues = contactManager.List();
            var messageInboxValues = messageManager.ListInbox(sessionUser);
            var messageSentValues = messageManager.ListSent(sessionUser);
            var messageDraftValues = messageManager.ListSent(sessionUser, null, false);
            //var messageSpamValues = messageManager.ListInbox(sessionUser, null, false);
            var messageTrashValues = messageManager.List(sessionUser, null, false);
            ContactModel contactModel = new ContactModel
            {
                ContactCount = contactValues.Count(c => !c.ContactStatusRead),
                MessageInboxCount = messageInboxValues.Count(m => !m.MessageReceiverStatusRead),
                MessageDraftCount = messageDraftValues.Count(m => !m.MessageSenderStatusRead),
                //MessageSpamCount = messageSpamValues.Count(m => !m.MessageReceiverStatusRead),
                MessageTrashCount = messageTrashValues.Count(m => m.MessageSender == sessionUser && !m.MessageSenderStatusRead)
                    + messageTrashValues.Count(m => m.MessageReceiver == sessionUser && !m.MessageReceiverStatusRead)
            };
            return PartialView(contactModel);
        }
    }
}
