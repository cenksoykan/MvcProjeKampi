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

        public List<Message> List(string address, bool status = true, string folder = "TRASH")
        {
            return _messageDal.List(x => (x.MessageReceiver == address || x.MessageSender == address) && x.MessageFolder == (status ? null : folder))
                .OrderByDescending(x => x.MessageDate)
                .ThenByDescending(x => x.MessageId)
                .ToList();
        }

        public List<Message> ListInbox(string receiver, bool status = true, string folder = "SPAM")
        {
            return _messageDal.List(x => x.MessageReceiver == receiver && x.MessageFolder == (status ? null : folder))
                .OrderByDescending(x => x.MessageDate)
                .ThenByDescending(x => x.MessageId)
                .ToList();
        }

        public List<Message> ListSent(string sender, bool status = true, string folder = "DRAFT")
        {
            return _messageDal.List(x => x.MessageSender == sender && x.MessageFolder == (status ? null : folder))
                .OrderByDescending(x => x.MessageDate)
                .ThenByDescending(x => x.MessageId)
                .ToList();
        }

        public void Insert(Message message)
        {
            message.MessageSender = "admin";
            _messageDal.Insert(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
