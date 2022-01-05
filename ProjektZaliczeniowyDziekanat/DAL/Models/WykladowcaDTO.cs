using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class WykladowcaDTO
    {
        [Key]
        public int WykladowcaID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string StopienNaukowy { get; set; }
        [ForeignKey("Przedmiot")]
        public string ProwadzonyPrzedmiot { get; set; }
        public string PESEL { get; set; }
        public string AdresZamieszkania { get; set; }
        public string MiejsceZamieszkania { get; set; }
        public string Narodowosc { get; set; }
        public string Obywatelstwo { get; set; }


        public virtual Przedmiot Przedmiot { get; set; }
    }
}
