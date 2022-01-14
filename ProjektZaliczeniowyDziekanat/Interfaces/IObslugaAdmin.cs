using ProjektZaliczeniowyDziekanat.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZaliczeniowyDziekanat.Interfaces
{
    public interface IObslugaAdmin
    {
        List<Zajecia> PobierzPlanZajecAsync();
        List<StudentDTO> PobierzListeStudentowAsync();
        List<WykladowcaDTO> PobierzListeWykladowcowAsync();
    }
}
