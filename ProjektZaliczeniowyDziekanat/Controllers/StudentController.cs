﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjektZaliczeniowyDziekanat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjektZaliczeniowyDziekanat.DAL.Models;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public StudentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
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