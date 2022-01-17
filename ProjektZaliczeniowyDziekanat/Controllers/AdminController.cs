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
            if (HttpContext.Session.GetInt32("adminID") != null) 
                return View();
            else 
                return BadRequest();

        }

        [HttpGet]
        public IActionResult PlanZajec(string searchString)
        {
            if (HttpContext.Session.GetInt32("adminID") != null)
            {
                

                ViewData["CurrentFilter"] = searchString;
                return View(obslugaAdmin.PobierzPlanZajec(searchString));
            }
            else 
                return BadRequest();
        }

        [HttpPost]
        [Route("DodajZajecia")]
        public IActionResult DodajZajecia(string GrupaNr, string NazwaPrzedmiotu, string TerminZajec, string WykladowcaID)
        {
            if (obslugaAdmin.DodajDoPlanu(GrupaNr, NazwaPrzedmiotu, TerminZajec, WykladowcaID))
                return BadRequest(new { komunikat = $"Należy poprawnie podać wszystkie dane!" });

            return RedirectToAction("PlanZajec", "Admin");
        }

        [HttpGet]
        [Route("UsunZajecia/{ZajeciaID}")]
        public IActionResult UsunZajecia(string ZajeciaID)
        {
            if (obslugaAdmin.UsunZPlanu(ZajeciaID))
                return BadRequest(new { komunikat = $"W bazie nie ma zajęć o podanej nazwie!" });

            return RedirectToAction("PlanZajec", "Admin");
        }

        [HttpGet]
        public IActionResult Studenci(string searchString)
        {
            if (HttpContext.Session.GetInt32("adminID") != null)
            {
                ViewData["CurrentFilter"] = searchString;
                return View(obslugaAdmin.PobierzListeStudentow(searchString));
            }
            else 
                return BadRequest();
        }

        [HttpPost]
        [Route("DodajStudent")]
        public IActionResult DodajStudent(string NumerIndeksu, string Imie, string Nazwisko, string DataUrodzenia, string MiejsceUrodzenia, string AdresZamieszkania, string MiejsceZamieszkania, string Narodowosc, string Obywatelstwo, string PESEL, string GrupaNr)
        {
            if (obslugaAdmin.DodajStudenta(NumerIndeksu, Imie, Nazwisko, DataUrodzenia, MiejsceUrodzenia, AdresZamieszkania, MiejsceZamieszkania, Narodowosc, Obywatelstwo, PESEL, GrupaNr))
                return BadRequest(new { komunikat = $"Należy poprawnie podać wszystkie dane!" });

            //return Ok(new { komunikat = $"Dodano studenta: {Imie} {Nazwisko} do bazy" });

            return RedirectToAction("Studenci", "Admin");
        }

        [HttpGet]
        [Route("UsunStudent/{StudentID}")]
        public IActionResult UsunStudent(string StudentID)
        {
            if (obslugaAdmin.UsunStudenta(StudentID))
                return BadRequest(new { komunikat = $"W bazie nie ma takiego studenta!" });

            //return Ok(new { komunikat = $"Usunięto studenta o ID: {StudentID} z bazy" });

            return RedirectToAction("Studenci", "Admin");
        }

        [HttpGet]
        public IActionResult Wykladowcy(string searchString)
        {
            if (HttpContext.Session.GetInt32("adminID") != null)
            {
                ViewData["CurrentFilter"] = searchString;
                return View(obslugaAdmin.PobierzListeWykladowcow(searchString));
            }
            else 
                return BadRequest();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
