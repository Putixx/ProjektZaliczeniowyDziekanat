using Microsoft.AspNetCore.Mvc;
using ProjektZaliczeniowyDziekanat.Models;
using System;
using System.Diagnostics;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            Student student = await obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));

            if (student == null)
                return BadRequest();
            else
                return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Dane()
        {           
            StudentDTO studentDTO = await obslugaStudent.ZalogowanyStudentDTO(HttpContext.Session.GetInt32("studentID"));
            Platnosc platnosc = await obslugaStudent.ZnajdzPlatnosc(HttpContext.Session.GetInt32("studentID"));
            ViewData["platnosc"] = platnosc.Kwota;
            ViewData["dataPlatnosci"] = platnosc.DataPlatnosci.ToString("d");
            if (studentDTO == null)
                return BadRequest();
            else
                return View(studentDTO);
        }


        [HttpGet]
        public async Task<IActionResult> PlanZajec(string sortOrder, string searchString)
        {
            Student ZalStudent = await obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));

            if (ZalStudent == null)
                return BadRequest();
            else
            {
                ViewData["DateSortPar"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
                ViewData["NameSortPar"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["CurrentFilter"] = searchString;
                var list = await obslugaStudent.WyswietlZajecia(ZalStudent, sortOrder, searchString);


                return View(list);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var student = await obslugaStudent.ZalogowanyStudent(HttpContext.Session.GetInt32("studentID"));
            ViewData["nadawca"] = $"{student.Imie} {student.Nazwisko}";
            return View();
        }
    }
}
