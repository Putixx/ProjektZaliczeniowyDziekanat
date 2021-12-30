using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.DAL.Contexts;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Http;

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
        public IActionResult LoginWykladowcy(WykladowcaLogowanie konto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string login = konto.Login;
                    string haslo = konto.Haslo;
                    WykladowcaLogowanie data = _context.WykladowcyLogowanie
                        .First(x => x.Login == login && x.Haslo == haslo);
                    if (data == null) return BadRequest();
                    Wykladowca wykladowca = _context.Wykladowcy.First(x => x.WykladowcaID == data.WykladowcaID);

                    HttpContext.Session.SetInt32("wykladowcaID", wykladowca.WykladowcaID);

                    return RedirectToAction(/*"Index", "Student", wykladowca*/);
                }
                return View();
            }
            catch(InvalidOperationException)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult LoginStudenta(StudentLogowanie konto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string login = konto.Login;
                    string haslo = konto.Haslo;
                    StudentLogowanie data = _context.StudenciLogowanie
                        .First(x => x.Login == login && x.Haslo == haslo);
                    if (data == null) return BadRequest(); //tymczasowo
                    Student student = _context.Studenci.First(x => x.StudentID == data.StudentID);

                    HttpContext.Session.SetInt32("studentID", student.StudentID);

                    return RedirectToAction("Index", "Student");
                }
                return View();
            }
            catch (InvalidOperationException)
            {
                return View();              
            }
        }
    }
}
