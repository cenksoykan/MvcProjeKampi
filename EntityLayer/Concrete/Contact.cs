using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        public string ContactUserName { get; set; }

        [StringLength(50)]
        public string ContactEmailAddress { get; set; }

        [StringLength(50)]
        public string ContactSubject { get; set; }

        [StringLength(2000)]
        public string ContactMessage { get; set; }

        public DateTime ContactDate { get; set; }

        public bool ContactStatusRead { get; set; }
    }
}
