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

        public async Task<List<Zajecia>> WyswietlZajecia(Student ZalStudent, string sortOrder, string searchString)
        {
            IQueryable<Zajecia> zajecia = await Task.Run(() => from z in dziekanatDb.PlanZajec where z.GrupaNr == ZalStudent.GrupaNr orderby z.TerminZajec select z);

            if (sortOrder == "date_desc" || sortOrder == "name_desc")
                zajecia = await SortujZajecia(sortOrder, zajecia);

            if (!String.IsNullOrEmpty(searchString))
                zajecia = await SzukajFrazyWZajeciach(searchString, zajecia);

            return zajecia.ToList();
        }
        
        public async Task<Student> ZalogowanyStudent(int? StudentID)
        {
            if (StudentID != null)
            {
                Student student = await Task.Run(() => dziekanatDb.Studenci.First(x => x.StudentID == StudentID));
                return student;
            }
            else
                return null;
        }

        public async Task<StudentDTO> ZalogowanyStudentDTO(int? StudentID)
        {
            if (StudentID != null)
            {
                StudentDTO studentDTO = await Task.Run(() => dziekanatDb.StudenciDTO.First(x => x.StudentID == StudentID)) ;
                return studentDTO;
            }
            else
                return null;
        }

        public async Task<IQueryable<Zajecia>> SortujZajecia(string sortOrder, IQueryable<Zajecia> zajecia)
        {
            switch (sortOrder)
            {
                case "date_desc":
                    zajecia = await Task.Run(() => zajecia.OrderByDescending(z => z.TerminZajec));
                    break;
                case "name_desc":
                    zajecia = await Task.Run(() => zajecia.OrderByDescending(z => z.NazwaPrzedmiotu));
                    break;
                default:
                    zajecia = await Task.Run(() => zajecia.OrderBy(z => z.TerminZajec));
                    break;
            }
            return zajecia;
        }

        public async Task<IQueryable<Zajecia>> SzukajFrazyWZajeciach(string searchString, IQueryable<Zajecia> zajecia)
        {
            if (!String.IsNullOrEmpty(searchString))
                zajecia = await Task.Run(() => zajecia.Where(z => z.NazwaPrzedmiotu.Contains(searchString)));

            return zajecia;
        }

        public async Task<Platnosc> ZnajdzPlatnosc(int? id)
        {
            Platnosc platnosc = await Task.Run(() => dziekanatDb.Platnosci.First(x => x.StudentID == id));
            return platnosc;
        }
    }
}
