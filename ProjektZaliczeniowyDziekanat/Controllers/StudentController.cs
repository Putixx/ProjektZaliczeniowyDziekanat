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
using Microsoft.AspNetCore.Http;
using ProjektZaliczeniowyDziekanat.DAL.Contexts;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IObslugaStudent obslugaDb;
        private readonly DziekanatContext _context;

        public StudentController(ILogger<HomeController> logger, IObslugaStudent obslugaDb, DziekanatContext context)
        {
            _logger = logger;
            this.obslugaDb = obslugaDb;
            _context = context;
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("studentID");
            Student loggedStudent = _context.Studenci.FirstOrDefault(x => x.StudentID == id);
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
