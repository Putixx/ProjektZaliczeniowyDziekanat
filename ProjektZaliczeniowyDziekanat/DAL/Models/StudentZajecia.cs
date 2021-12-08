using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class StudentZajecia
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        [ForeignKey("Zajecia")]
        public int ZajeciaID { get; set; }
        public Zajecia Zajecia { get; set; }
        public DateTime DataZaplanowanegoEgzaminu { get; set; }

        StudentZajecia() { }
    }
}
