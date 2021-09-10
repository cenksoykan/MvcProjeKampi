using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> List(string address, string q = null, bool status = true, string folder = "TRASH")
        {
            string[] words = q?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var messages = String.IsNullOrEmpty(q) ? _messageDal.List() : _messageDal.List(m => words.All(w => m.MessageSender.Contains(w) || m.MessageReceiver.Contains(w) || m.MessageSubject.Contains(w) || m.MessageBody.Contains(w)));

            return messages.Where(x => x.MessageReceiver == address && x.MessageReceiverFolder == (status ? null : folder) && x.MessageSenderFolder != "DRAFT")
                .Union(messages.Where(x => x.MessageSender == address && x.MessageSenderFolder == (status ? null : folder)))
                .OrderByDescending(x => x.MessageDate)
                .ThenByDescending(x => x.MessageId)
                .ToList();
        }

        public List<Message> ListInbox(string receiver, string q = null, bool status = true, string folder = "SPAM")
        {
            string[] words = q?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var messages = String.IsNullOrEmpty(q) ? _messageDal.List() : _messageDal.List(m => words.All(w => m.MessageSender.Contains(w) || m.MessageReceiver.Contains(w) || m.MessageSubject.Contains(w) || m.MessageBody.Contains(w)));

            return messages.Where(x => x.MessageReceiver == receiver && x.MessageReceiverFolder == (status ? null : folder) && x.MessageSenderFolder != "DRAFT")
                .OrderByDescending(x => x.MessageDate)
                .ThenByDescending(x => x.MessageId)
                .ToList();
        }

        public List<Message> ListSent(string sender, string q = null, bool status = true, string folder = "DRAFT")
        {
            string[] words = q?.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var messages = String.IsNullOrEmpty(q) ? _messageDal.List() : _messageDal.List(m => words.All(w => m.MessageSender.Contains(w) || m.MessageReceiver.Contains(w) || m.MessageSubject.Contains(w) || m.MessageBody.Contains(w)));

            return messages.Where(x => x.MessageSender == sender && x.MessageSenderFolder == (status ? null : folder))
                .OrderByDescending(x => x.MessageDate)
                .ThenByDescending(x => x.MessageId)
                .ToList();
        }

        public void Insert(Message message)
        {
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.MessageReceiverStatusRead = false;
            message.MessageReceiverFolder = null;
            if (message.MessageSenderFolder != "DRAFT") message.MessageSenderFolder = null;
            _messageDal.Insert(message);
        }

        public Message GetById(int id = 0)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
