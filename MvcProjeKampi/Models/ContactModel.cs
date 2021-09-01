using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.Models
{
    public class ContactModel
    {
        public int ContactCount { get; set; }
        public int MessageInboxCount { get; set; }
        public int MessageDraftCount { get; set; }
        //public int MessageSpamCount { get; set; }
        public int MessageTrashCount { get; set; }
    }
}