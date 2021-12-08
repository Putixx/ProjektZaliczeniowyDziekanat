

using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektZaliczeniowyDziekanat.DAL.Models
{
    public class WykladowcaLogowanie
    {
        [ForeignKey("Wykladowca")]
        public int WykladowcaID { get; set; }
        public Wykladowca Wykladowca { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
    }
}
