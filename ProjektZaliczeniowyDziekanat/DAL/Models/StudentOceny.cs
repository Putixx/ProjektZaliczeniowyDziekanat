using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    [Keyless]
    public class StudentOceny
    {
        [ForeignKey("StudentZajecia")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("StudentZajecia")]
        public int ZajeciaID { get; set; }
        public virtual Zajecia Zajecia { get; set; }
        [Range(2,6)]
        public float Ocena { get; set; }

    }
}
