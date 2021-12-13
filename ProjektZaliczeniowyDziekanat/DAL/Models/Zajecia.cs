using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class Zajecia
    {
        [Key]
        public int ZajeciaID { get; set; }
        public string NazwaZajec { get; set; }
        public DateTime TerminZajec { get; set; }
        [ForeignKey("Wykladowca")]
        public int WykladowcaID { get; set; }
        public virtual Wykladowca Wykladowca { get; set; }

        Zajecia() { }
    }
}
