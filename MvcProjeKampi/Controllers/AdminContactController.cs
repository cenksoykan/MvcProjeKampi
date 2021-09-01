using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles = "A")]
    public class AdminContactController : Controller
    {
        // GET: AdminContact
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = contactManager.List();
            return View(contactValues);
        }

        public ActionResult ContactDetails(int id)
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
            ViewBag.ActionName = "Index";
            return View(contactDetailModel);
        }

        public PartialViewResult ContactNavPartial()
        {
            var contactValues = contactManager.List();
            var messageInboxValues = messageManager.ListInbox("admin");
            var messageSentValues = messageManager.ListSent("admin");
            var messageDraftValues = messageManager.ListSent("admin", false);
            //var messageSpamValues = messageManager.ListInbox("admin", false);
            var messageTrashValues = messageManager.List("admin", false);
            ContactModel contactModel = new ContactModel
            {
                ContactCount = contactValues.Count(c => !c.ContactStatusRead),
                MessageInboxCount = messageInboxValues.Count(m => !m.MessageStatusRead),
                MessageDraftCount = messageDraftValues.Count(m => !m.MessageStatusRead),
                //MessageSpamCount = messageSpamValues.Count(m => !m.MessageStatusRead),
                MessageTrashCount = messageTrashValues.Count(m => !m.MessageStatusRead),
            };
            return PartialView(contactModel);
        }
    }
}