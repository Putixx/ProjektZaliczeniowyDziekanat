using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjektZaliczeniowyDziekanat.Services
{
    public class ObslugaStudent : IObslugaStudent
    {
        private readonly DziekanatContext dziekanatDb;

        public ObslugaStudent(DziekanatContext dziekanatDb)
        {
            this.dziekanatDb = dziekanatDb;
        }

        public List<Zajecia> WyswietlZajecia(Student ZalStudent, string sortOrder, string searchString)
        {
            IQueryable<Zajecia> zajecia = from z in dziekanatDb.PlanZajec where z.GrupaNr == ZalStudent.GrupaNr orderby z.TerminZajec select z;

            if (sortOrder == "date_desc" || sortOrder == "name_desc")
                zajecia = SortujZajecia(sortOrder, zajecia);

            if (!String.IsNullOrEmpty(searchString))
                zajecia = SzukajFrazyWZajeciach(searchString, zajecia);

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

        public StudentDTO ZalogowanyStudentDTO(int? StudentID)
        {
            if (StudentID != null)
            {
                StudentDTO studentDTO = dziekanatDb.StudenciDTO.First(x => x.StudentID == StudentID);
                return studentDTO;
            }
            else
                return null;
        }

        public IQueryable<Zajecia> SortujZajecia(string sortOrder, IQueryable<Zajecia> zajecia)
        {
            switch (sortOrder)
            {
                case "date_desc":
                    zajecia = zajecia.OrderByDescending(z => z.TerminZajec);
                    break;
                case "name_desc":
                    zajecia = zajecia.OrderByDescending(z => z.NazwaPrzedmiotu);
                    break;
                default:
                    zajecia = zajecia.OrderBy(z => z.TerminZajec);
                    break;
            }
            return zajecia;
        }

        public IQueryable<Zajecia> SzukajFrazyWZajeciach(string searchString, IQueryable<Zajecia> zajecia)
        {
            if (!String.IsNullOrEmpty(searchString))
                zajecia = zajecia.Where(z => z.NazwaPrzedmiotu.Contains(searchString));

            return zajecia;
        }

        public Platnosc ZnajdzPlatnosc(int? id)
        {
            Platnosc platnosc = dziekanatDb.Platnosci.First(x => x.StudentID == id);
            return platnosc;
        }
    }
}
