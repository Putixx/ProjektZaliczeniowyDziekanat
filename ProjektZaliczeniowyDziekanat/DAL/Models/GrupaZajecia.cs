using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    [Keyless]
    public class GrupaZajecia
    {
        [ForeignKey("Grupa")]
        public string GrupaNr { get; set; }
        public virtual Grupa Grupa { get; set; }

        public List<Zajecia> PlanZajec { get; set; }
    }
}
