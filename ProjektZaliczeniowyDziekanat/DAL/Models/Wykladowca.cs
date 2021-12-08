using System;
using System.ComponentModel.DataAnnotations;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class Wykladowca
    {
        [Key]
        public int WykladowcaID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public string StopienNaukowy { get; set; }
        public string PESEL { get; set; }

        Wykladowca() { }
    }
}
