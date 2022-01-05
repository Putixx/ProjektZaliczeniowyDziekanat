using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjektZaliczeniowyDziekanat.Services
{
    public class ObslugaWykladowca : IObslugaWykladowca
    {
        private readonly DziekanatContext dziekanatDb;

        public ObslugaWykladowca(DziekanatContext dziekanatDb)
        {
            this.dziekanatDb = dziekanatDb;
        }

        public List<Zajecia> WyswietlZajecia(Wykladowca ZalWykladowca)
        {
            IQueryable<Zajecia> zajecia = from z in dziekanatDb.PlanZajec where z.WykladowcaID == ZalWykladowca.WykladowcaID  orderby z.TerminZajec select z;

            return zajecia.ToList();
        }
        
        public Wykladowca ZalogowanyWykladowca(int? WykladowcaID)
        {
            if (WykladowcaID != null)
            {
                Wykladowca wykladowca = dziekanatDb.Wykladowcy.First(x => x.WykladowcaID == WykladowcaID);
                return wykladowca;
            }
            else
                return null;
        }

        public WykladowcaDTO ZalogowanyWykladowcaDTO(int? WykladowcaID)
        {
            if (WykladowcaID != null)
            {
                WykladowcaDTO wykladowcaDTO = dziekanatDb.WykladowcyDTO.First(x => x.WykladowcaID == WykladowcaID);
                return wykladowcaDTO;
            }
            else
                return null;
        }
    }
}
