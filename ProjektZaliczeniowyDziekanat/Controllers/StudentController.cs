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
        private readonly IObslugaStudent obslugaStudent;

        public StudentController(ILogger<HomeController> logger, IObslugaStudent obslugaStudent)
        {
            _logger = logger;
            this.obslugaStudent = obslugaStudent;
        }

        [HttpGet]
        [Route("Home")]
        public IActionResult Index()
        {
            Student student = obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));

            if (student == null)
                return BadRequest();
            else
                return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult PlanZajec()
        {
            Student ZalStudent = obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));

            if (ZalStudent == null)
                return BadRequest();
            else
                return View(obslugaStudent.WyswietlZajecia(ZalStudent));
        }
    }
}
