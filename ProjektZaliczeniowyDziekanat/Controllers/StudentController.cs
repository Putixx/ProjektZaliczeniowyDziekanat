using Microsoft.AspNetCore.Mvc;
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
        

        public StudentController(IObslugaStudent obslugaStudent)
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

        [HttpGet]
        public IActionResult Dane()
        {           
            StudentDTO studentDTO = obslugaStudent.ZalogowanyStudentDTO(HttpContext.Session.GetInt32("studentID"));
            ViewData["platnosc"] = obslugaStudent
                .ZnajdzPlatnosc(HttpContext.Session.GetInt32("studentID"))
                .Kwota;
            ViewData["dataPlatnosci"] = obslugaStudent
                .ZnajdzPlatnosc(HttpContext.Session.GetInt32("studentID"))
                .DataPlatnosci.ToString("d");
            if (studentDTO == null)
                return BadRequest();
            else
                return View(studentDTO);
        }


        [HttpGet]
        public IActionResult PlanZajec(string sortOrder, string searchString)
        {
            Student ZalStudent = obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));

            if (ZalStudent == null)
                return BadRequest();
            else
            {
                ViewData["DateSortPar"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
                ViewData["NameSortPar"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["CurrentFilter"] = searchString;


                return View(obslugaStudent.WyswietlZajecia(ZalStudent, sortOrder, searchString));
            }
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["nadawca"] = $"{obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID")).Imie} {obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID")).Nazwisko}";
            return View();
        }
    }
}
