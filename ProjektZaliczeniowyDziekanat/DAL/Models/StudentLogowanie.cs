using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class StudentLogowanie
    {
        [ForeignKey("Student")]
        [HiddenInput]
        public int StudentID { get; set; }
        [HiddenInput]
        public Student Student { get; set; }
        [Required(ErrorMessage="Proszę podać login")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Proszę podać hasło")]
        public string Haslo { get; set; }
    }
}
