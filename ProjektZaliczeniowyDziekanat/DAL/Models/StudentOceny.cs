using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class StudentOceny
    {
        [ForeignKey("StudentZajecia")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        [ForeignKey("StudentZajecia")]
        public int ZajeciaID { get; set; }
        public Zajecia Zajecia { get; set; }
        public DateTime DataEgzaminu { get; set; }
        [ForeignKey("Ocena")]
        public int Ocena { get; set; }
        public Ocena Ocenaa { get; set; }

        StudentOceny() { }
    }
}
