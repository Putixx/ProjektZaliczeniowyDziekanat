using ProjektZaliczeniowyDziekanat.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjektZaliczeniowyDziekanat.Interfaces
{
    public interface IObslugaStudent
    {
        List<Zajecia> WyswietlZajecia(Student ZalStudent, string sortOrder, string searchString);
        Student ZalogowanyStudent(int? StudentID);
        IQueryable<Zajecia> SortujZajecia(string sortOrder, IQueryable<Zajecia> zajecia);
        IQueryable<Zajecia> SzukajFrazyWZajeciach(string searchString, IQueryable<Zajecia> zajecia);
    }
}
