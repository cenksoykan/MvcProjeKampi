using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class PersonaSkillManager : IPersonaSkillService
    {
        IPersonaSkillDal _personaSkillDal;

        public PersonaSkillManager(IPersonaSkillDal personaSkillDal)
        {
            _personaSkillDal = personaSkillDal;
        }

        public List<PersonaSkill> List()
        {
            return _personaSkillDal.List(x => x.PersonaSkillIndex > 0 && x.Persona.PersonaStatus).OrderBy(x => x.PersonaSkillIndex).ToList();
        }

        public List<PersonaSkill> ListByPersona(int id)
        {
            return _personaSkillDal.List(x => x.PersonaId == id && x.PersonaSkillIndex > 0 && x.Persona.PersonaStatus).OrderBy(x => x.PersonaSkillIndex).ToList();
        }

        public void Insert(PersonaSkill personaSkill)
        {
            _personaSkillDal.Insert(personaSkill);
        }

        public PersonaSkill GetById(int id)
        {
            return _personaSkillDal.Get(x => x.PersonaSkillId == id);
        }

        public void Update(PersonaSkill personaSkill)
        {
            _personaSkillDal.Update(personaSkill);
        }
    }
}
