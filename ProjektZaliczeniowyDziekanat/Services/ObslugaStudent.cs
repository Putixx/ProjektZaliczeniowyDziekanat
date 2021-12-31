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

        public List<Zajecia> WyswietlZajecia(Student ZalStudent)
        {
            IQueryable<Zajecia> zajecia = from z in dziekanatDb.PlanZajec where z.GrupaNr == ZalStudent.GrupaNr select z;

            return zajecia.ToList();
        }
        
        public Student ZalogowanyStudent(int? StudentID)
        {
            if (StudentID != null)
            {
                Student student = dziekanatDb.Studenci.First(x => x.StudentID == StudentID);
                return student;
            }
            else
                return null;
        }
    }
}
