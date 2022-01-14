using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZaliczeniowyDziekanat.Services
{
    public class ObslugaAdmin : IObslugaAdmin
    {
        private readonly DziekanatContext dziekanatDb;

        public ObslugaAdmin(DziekanatContext dziekanatDb)
        {
            this.dziekanatDb = dziekanatDb;
        }

        public List<Zajecia> PobierzPlanZajecAsync()
        {
            return dziekanatDb.PlanZajec.ToList();
        }

        public List<StudentDTO> PobierzListeStudentowAsync()
        {
            return dziekanatDb.StudenciDTO.ToList();
        }

        public List<WykladowcaDTO> PobierzListeWykladowcowAsync()
        {
            return dziekanatDb.WykladowcyDTO.ToList();
        }

    }
}
