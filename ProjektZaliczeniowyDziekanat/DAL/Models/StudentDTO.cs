using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class StudentDTO
    {
        [Key]
        public int StudentID { get; set; }
        public string NumerIndeksu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string MiejsceUrodzenia { get; set; }
        public string AdresZamieszkania { get; set; }
        public string MiejsceZamieszkania { get; set; }
        public string Narodowosc { get; set; }
        public string Obywatelstwo { get; set; }
        public string PESEL { get; set; }
        [ForeignKey("Grupa")]
        public string GrupaNr { get; set; }



        public virtual Grupa Grupa { get; set; }
    }
}
