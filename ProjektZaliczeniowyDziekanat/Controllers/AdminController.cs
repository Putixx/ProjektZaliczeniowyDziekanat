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
        public IActionResult PlanZajec()
        {
            if (HttpContext.Session.GetInt32("adminID") != null) 
                return View(obslugaAdmin.PobierzPlanZajecAsync());
            else 
                return BadRequest();
        }

        [HttpGet]
        public IActionResult Studenci()
        {
            if (HttpContext.Session.GetInt32("adminID") != null) 
                return View(obslugaAdmin.PobierzListeStudentowAsync());
            else 
                return BadRequest();
        }

        [HttpGet]
        public IActionResult Wykladowcy()
        {
            if (HttpContext.Session.GetInt32("adminID") != null) 
                return View(obslugaAdmin.PobierzListeWykladowcowAsync());
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
