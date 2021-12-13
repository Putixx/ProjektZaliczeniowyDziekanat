﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    [Keyless]
    public class WykladowcaLogowanie
    {
        [ForeignKey("Wykladowca")]
        public int WykladowcaID { get; set; }
        public virtual Wykladowca Wykladowca { get; set; }
        [Required(ErrorMessage = "Proszę podać login")]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Proszę podać hasło")]
        public string Haslo { get; set; }
    }
}
