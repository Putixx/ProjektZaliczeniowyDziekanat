using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string NumerIndeksu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        [ForeignKey("Grupa")]
        public string GrupaNr { get; set; }


        public virtual Grupa Grupa { get; set; }
    }
}
