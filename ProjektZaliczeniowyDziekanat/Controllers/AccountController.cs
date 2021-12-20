using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class AccountController : Controller
    {
        private readonly DziekanatContext _context;

        public AccountController(DziekanatContext context)
        {
            _context = context;
        }

        public IActionResult UserRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginStudenta()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginWykladowcy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyWykladowca(WykladowcaLogowanie konto)
        {

            string login = konto.Login;
            string haslo = konto.Haslo;

            var userQuery = from WykladowcaLogowanie in _context.WykladowcyLogowanie
                            where WykladowcaLogowanie.Login == login && WykladowcaLogowanie.Haslo == haslo
                            select WykladowcaLogowanie.Login;

            if (userQuery == null)
            {
                return null;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult VerifyStudent(StudentLogowanie konto)
        {
            
            string login = konto.Login;
            string haslo = konto.Haslo;

            var userQuery = from StudentLogowanie in _context.StudenciLogowanie
                            where StudentLogowanie.Login == login && StudentLogowanie.Haslo == haslo
                            select StudentLogowanie.Login;

            if (userQuery == null)
            {
                return null;
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
