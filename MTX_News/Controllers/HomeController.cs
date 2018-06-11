using MTX_News.Infrastructure;
using MTX_News.Models;
using MTX_News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace MTX_News.Controllers
{
    public class HomeController : Controller
    {
        KomentarzManager komentarzManager;
        SessionManager session = new SessionManager();

        public ActionResult Index()
        {
            return View();
        }

        public HomeController()
        {
            komentarzManager = new KomentarzManager();
        }

        //[ChildActionOnly]
        public ActionResult ProduktyZKomentarzami()
        {
            Random rnd = new Random(10);
            List<Produkt> produkts = new List<Produkt>();
            string sesja = session.GetSessionID();
            for(int i=1;i<=100;i++)
            {
                produkts.Add(
                    new Produkt
                    {
                        ProduktId = i,
                        Kod = "Kod-komórka " + i.ToString(),
                        Nazwa = "Nazwa-komórka " + i.ToString(),
                        Komentarz = "Komentarz-komórka " + i.ToString(),
                        PozostalaLiczbaDniDoKoncaWaznosci = rnd.Next(1, 30),
                        KtoWprowadzil = sesja
                    });
            }
            KomentarzViewModel vm = new KomentarzViewModel();
            vm.ListaProduktow = produkts;
            return PartialView("_ProduktyZKomentarzami", vm);
        }

        public ActionResult FormularzKomentarza()
        {
            var produkt = new Produkt();
            return PartialView("_FormularzKomentarza", produkt);
        }

        [HttpPost]
        public ActionResult FormularzKomentarza(Produkt produkt)
        {
            komentarzManager.DodajKomentarz(produkt);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Szukaj(FiltrViewModel vm)
        {
            string kod = vm.Kod;
            string nazwa = vm.Nazwa;
            bool czyJestKom = vm.ZawieraKomentarz;

            return RedirectToAction("Index");
        }
        
    }
}