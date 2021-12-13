using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    [Keyless]
    public class StudentLogowanie
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        [Required(ErrorMessage = "Proszę podać login")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Proszę podać hasło")]
        public string Haslo { get; set; }
    }
}
