using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }

        [StringLength(50)]
        public string PersonaName { get; set; }
        
        [StringLength(50)]
        public string PersonaSurname { get; set; }

        [StringLength(50)]
        public string PersonaTitle { get; set; }

        [StringLength(500)]
        public string PersonaEmailAddress { get; set; }

        [StringLength(500)]
        public string PersonaProfilePicture { get; set; }

        public bool PersonaStatus { get; set; }

        public ICollection<PersonaSkill> PersonaSkills { get; set; }
    }
}
