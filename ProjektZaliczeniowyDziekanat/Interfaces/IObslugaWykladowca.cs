using ProjektZaliczeniowyDziekanat.DAL.Models;
using System.Collections.Generic;

namespace ProjektZaliczeniowyDziekanat.Interfaces
{
    public interface IObslugaWykladowca
    {
        List<Zajecia> WyswietlZajecia(Wykladowca ZalWykladowca);
        Wykladowca ZalogowanyWykladowca(int? WykladowcaID);
        WykladowcaDTO ZalogowanyWykladowcaDTO(int? WykladowcaID);
    }
}
