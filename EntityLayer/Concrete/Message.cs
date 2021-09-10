using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [StringLength(500)]
        public string MessageSender { get; set; }

        [StringLength(500)]
        public string MessageReceiver { get; set; }

        [StringLength(50)]
        public string MessageSubject { get; set; }

        [AllowHtml]
        [StringLength(8000)]
        public string MessageBody { get; set; }

        public DateTime MessageDate { get; set; }

        public bool MessageSenderStatusRead { get; set; }

        [StringLength(8)]
        public string MessageSenderFolder { get; set; }

        public bool MessageReceiverStatusRead { get; set; }

        [StringLength(8)]
        public string MessageReceiverFolder { get; set; }
    }
}
