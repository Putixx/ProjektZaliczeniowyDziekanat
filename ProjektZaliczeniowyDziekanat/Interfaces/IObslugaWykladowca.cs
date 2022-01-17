using ProjektZaliczeniowyDziekanat.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjektZaliczeniowyDziekanat.Interfaces
{
    public interface IObslugaWykladowca
    {
        Task<List<Zajecia>> WyswietlZajecia(Wykladowca ZalWykladowca);
        Task<Wykladowca> ZalogowanyWykladowca(int? WykladowcaID);
        Task<WykladowcaDTO> ZalogowanyWykladowcaDTO(int? WykladowcaID);
    }
}
