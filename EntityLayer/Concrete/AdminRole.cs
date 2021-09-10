using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AdminRole
    {
        [Key]
        [StringLength(1)]
        public string AdminRoleCode { get; set; }

        public ICollection<Admin> Admins { get; set; }
    }
}
