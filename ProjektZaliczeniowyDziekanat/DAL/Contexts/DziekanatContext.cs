using Microsoft.EntityFrameworkCore;
using ProjektZaliczeniowyDziekanat.DAL.Models;

namespace ProjektZaliczeniowyDziekanat.DAL.Contexts
{
    public class DziekanatContext : DbContext 
    {

        public DziekanatContext(DbContextOptions<DziekanatContext> options) : base(options) {    }

        public DbSet<StudentLogowanie> StudenciLogowanie { get; set; } 
        public DbSet<Finanse> Finanse { get; set; }
        public DbSet<Grupa> Grupy { get; set; }
        public DbSet<Student> Studenci { get; set; }
        public DbSet<StudentOceny> StudentOceny { get; set; }
        public DbSet<Wykladowca> Wykladowcy { get; set; }
        public DbSet<WykladowcaLogowanie> WykladowcyLogowanie { get; set; }
        public DbSet<Zajecia> Zajecia { get; set; }




    }
}
