using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PersonaSkill
    {
        [Key]
        public int PersonaSkillId { get; set; }

        [StringLength(50)]
        public string PersonaSkillName { get; set; }

        public int PersonaSkillLevel { get; set; }

        public int PersonaSkillIndex { get; set; }

        public int PersonaId { get; set; }

        public virtual Persona Persona { get; set; }
    }
}
