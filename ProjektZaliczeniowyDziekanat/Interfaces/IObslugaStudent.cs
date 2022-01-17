using ProjektZaliczeniowyDziekanat.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZaliczeniowyDziekanat.Interfaces
{
    public interface IObslugaStudent
    {
        Task<List<Zajecia>> WyswietlZajecia(Student ZalStudent, string sortOrder, string searchString);
        Task<Student> ZalogowanyStudent(int? StudentID);
        Task<StudentDTO> ZalogowanyStudentDTO(int? StudentID);
        Task<IQueryable<Zajecia>> SortujZajecia(string sortOrder, IQueryable<Zajecia> zajecia);
        Task<IQueryable<Zajecia>> SzukajFrazyWZajeciach(string searchString, IQueryable<Zajecia> zajecia);
        Task<Platnosc> ZnajdzPlatnosc(int? id);
    }
}
