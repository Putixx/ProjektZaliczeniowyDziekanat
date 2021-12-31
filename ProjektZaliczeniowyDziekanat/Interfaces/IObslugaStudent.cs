using ProjektZaliczeniowyDziekanat.DAL.Models;
using System.Collections.Generic;

namespace ProjektZaliczeniowyDziekanat.Interfaces
{
    public interface IObslugaStudent
    {
        List<Zajecia> WyswietlZajecia(Student ZalStudent);
        Student ZalogowanyStudent(int? StudentID);
    }
}
