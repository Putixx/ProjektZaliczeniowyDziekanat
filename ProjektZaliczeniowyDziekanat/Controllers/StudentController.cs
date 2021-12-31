using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjektZaliczeniowyDziekanat.Models;
using System;
using System.Diagnostics;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class StudentController : Controller
    {
        private readonly IObslugaStudent obslugaStudent;

        public StudentController(ILogger<HomeController> logger, IObslugaStudent obslugaStudent)
        {
            this.obslugaStudent = obslugaStudent;
        }

        [HttpGet]
        [Route("Student/Home")]
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
        public IActionResult PlanZajec(string sortOrder, string searchString)
        {
            Student ZalStudent = obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));

            if (ZalStudent == null)
                return BadRequest();
            else
            {
                ViewData["IndexSortPar"] = String.IsNullOrEmpty(sortOrder) ? "index_desc" : "";
                ViewData["DateSortPar"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
                ViewData["NameSortPar"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["CurrentFilter"] = searchString;


                return View(obslugaStudent.WyswietlZajecia(ZalStudent, sortOrder, searchString));
            }
        }
    }
}
