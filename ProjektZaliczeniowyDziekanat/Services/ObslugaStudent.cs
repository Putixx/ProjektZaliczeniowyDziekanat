using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZaliczeniowyDziekanat.Services
{
    public class ObslugaStudent : IObslugaStudent
    {
        private readonly DziekanatContext dziekanatDb;

        public ObslugaStudent(DziekanatContext dziekanatDb)
        {
            this.dziekanatDb = dziekanatDb;
        }

        public List<Zajecia> WyswietlZajecia()
        {
            IQueryable<Zajecia> zajecia = from z in dziekanatDb.PlanZajec select z;

            return zajecia.ToList();
        }
    }
}
