using Microsoft.AspNetCore.Mvc;
using ProjektZaliczeniowyDziekanat.Models;
using System.Diagnostics;
using ProjektZaliczeniowyDziekanat.DAL.Models;
using ProjektZaliczeniowyDziekanat.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ProjektZaliczeniowyDziekanat.Controllers
{
    public class WykladowcaController : Controller
    {
        private readonly IObslugaWykladowca obslugaWykladowca;

        public WykladowcaController(IObslugaWykladowca obslugaWykladowca)
        {
            this.obslugaWykladowca = obslugaWykladowca;
        }

        [HttpGet]
        [Route("Wykladowca/Home")]
        public IActionResult Index()
        {
            Wykladowca wykladowca = obslugaWykladowca.ZalogowanyWykladowca(HttpContext.Session.GetInt32("wykladowcaID"));

            if (wykladowca == null)
                return BadRequest();
            else
                return View(wykladowca);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult PlanZajec()
        {
            Wykladowca ZalWykladowca = obslugaWykladowca.ZalogowanyWykladowca(HttpContext.Session.GetInt32("wykladowcaID"));

            if (ZalWykladowca == null)
                return BadRequest();
            else
                return View(obslugaWykladowca.WyswietlZajecia(ZalWykladowca));
        }

        [HttpGet]
        public IActionResult Dane()
        {
            WykladowcaDTO ZalWykladowca = obslugaWykladowca.ZalogowanyWykladowcaDTO(HttpContext.Session.GetInt32("wykladowcaID"));
            return View(ZalWykladowca);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

    }
}
