using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class StudentLogowanie
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}
