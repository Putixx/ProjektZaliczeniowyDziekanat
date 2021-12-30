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
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IObslugaStudent obslugaDb;
        private Student loggedStudent;

        public StudentController(ILogger<HomeController> logger, IObslugaStudent obslugaDb)
        {
            _logger = logger;
            this.obslugaDb = obslugaDb;
        }

        [HttpGet]
        public IActionResult Index(Student student)
        {
            loggedStudent = student;
            return View(loggedStudent);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult PlanZajec()
        {
            return View(obslugaDb.WyswietlZajecia());
        }
    }
}
