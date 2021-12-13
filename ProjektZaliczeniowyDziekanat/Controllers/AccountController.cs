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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Verify(StudentLogowanie konto)
        {
            
            string login = konto.Login;
            string haslo = konto.Haslo;

            var userQuery = from StudentLogowanie in _context.StudenciLogowanie
                            where StudentLogowanie.Login == login && StudentLogowanie.Haslo == haslo
                            select StudentLogowanie.Login;

            return RedirectToAction("Index", "Home");
        }

    }
}
