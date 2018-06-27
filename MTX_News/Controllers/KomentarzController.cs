using MTX_News.Infrastructure;
using MTX_News.Models;
using MTX_News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTX_News.Controllers
{
    public class KomentarzController : Controller
    {
        KomentarzManager komentarzMaganer = new KomentarzManager();
        FiltrViewModel filtr;

        // GET: Komentarz
        public ActionResult Index(string kod, string nazwa, bool? zkomentarzem, string producent)
        {
            filtr = new FiltrViewModel()
            {
                Kod=kod,
                Nazwa = nazwa,
                ZawieraKomentarz = zkomentarzem ?? false,
                Producent = producent
            };
            
            var komentarze = komentarzMaganer.PobierzKomentarzeZBazy(filtr);
            return View(komentarze.ToList());
        }

        public ActionResult FormularzKomentarza(Produkt produkt)
        {            
            return PartialView("_FormularzKomentarza", produkt);
        }
        
        [HttpPost]
        public ActionResult ZapiszKomentarz(KomentarzViewModel komentarz)
        {
            if (ModelState.IsValid)
            {
                Produkt produkt = new Produkt()
                {
                    Kod = komentarz.Kod,
                    Nazwa = komentarz.Nazwa,
                    Komentarz = komentarz.Komentarz,
                    PozostalaLiczbaDniDoKoncaWaznosci = komentarz.PozostalaLiczbaDniDoKoncaWaznosci,
                    KtoWprowadzil = komentarz.KtoWprowadzil
                };
                komentarzMaganer.DodajKomentarz(produkt);
                return Json(komentarz);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult UsunKomentarz(int produktId)
        {
            komentarzMaganer.ZmienStatusNaNieaktywny(produktId);
            return Json("");
        }
    }
}