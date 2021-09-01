using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPersonaSkillService
    {
        List<PersonaSkill> List();
        void Insert(PersonaSkill personaSkill);
        List<PersonaSkill> ListByPersona(int id);
        PersonaSkill GetById(int id);
        void Update(PersonaSkill personaSkill);
    }
}
