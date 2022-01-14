using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjektZaliczeniowyDziekanat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class AdminController : Controller
    {
        private readonly IObslugaAdmin obslugaAdmin;

        public AdminController(IObslugaAdmin obslugaAdmin)
        {
            this.obslugaAdmin = obslugaAdmin;
        }

        [HttpGet]
        public IActionResult Index()
        {                      
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
