using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjektZaliczeniowyDziekanat.DAL.Contexts
{
    public class DziekanatContext : DbContext 
    {

        public DziekanatContext(DbContextOptions<DziekanatContext> options) : base(options)
        {

        }


    }
}
