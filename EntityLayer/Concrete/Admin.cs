using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminUsername { get; set; }

        [StringLength(256)]
        public string AdminPassword { get; set; }

        public bool AdminStatus { get; set; }

        public string AdminRoleCode { get; set; }

        public virtual AdminRole AdminRole { get; set; }
    }
}
