using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> List(string address, string q, bool status, string folder);
        List<Message> ListInbox(string receiver, string q, bool status, string folder);
        List<Message> ListSent(string sender, string q, bool status, string folder);
        void Insert(Message message);
        Message GetById(int id);
        void Update(Message message);
    }
}
