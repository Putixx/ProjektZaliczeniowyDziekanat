﻿using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using ProjektZaliczeniowyDziekanat.Interfaces;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IObslugaAccount obslugaAccount;

        public AccountController(IObslugaAccount obslugaAccount)
        {
            this.obslugaAccount = obslugaAccount;
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
        public IActionResult LoginWykladowcy(string Login, string Haslo)
        {
            try
            {
                if (obslugaAccount.WyszukajWykladowceDoZalogowania(Login, Haslo))
                {
                    HttpContext.Session.SetInt32("wykladowcaID", obslugaAccount.PobierzZalogowanegoWykladowce(Login, Haslo).WykladowcaID);
                    ViewData["BadLogin"] = "";
                    ViewData["ctrl"] = "Student";
                    return RedirectToAction("Index", "Wykladowca");
                }
                else
                    return BadRequest();

            }
            catch (InvalidOperationException)
            {
                ViewData["BadLogin"] = "Zły login lub hasło";
                return View();
            }
        }

        [HttpPost]
        public IActionResult LoginStudenta(string Login, string Haslo)
        {
            try
            {
                if (obslugaAccount.WyszukajStudentaDoZalogowania(Login, Haslo))
                {
                    HttpContext.Session.SetInt32("studentID", obslugaAccount.PobierzZalogowanegoStudenta(Login, Haslo).StudentID);
                    ViewData["BadLogin"] = "";
                    ViewData["ctrl"] = "Wykladowca";
                    return RedirectToAction("Index", "Student");
                }
                else
                    return BadRequest();

            }
            catch (InvalidOperationException)
            {
                ViewData["BadLogin"] = "Zły login lub hasło";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("UserRole", "Account");
        }
    }
}
