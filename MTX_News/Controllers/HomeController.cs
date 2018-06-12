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
        KomentarzViewModel vm;

        public ActionResult Index()
        {
            return View();
        }

        public HomeController()
        {
            komentarzManager = new KomentarzManager();
            vm = new KomentarzViewModel();
        }

        public ActionResult ProduktyZKomentarzami()
        {
            vm.ListaProduktow = komentarzManager.PobierzKomentarzeZBazy();
            return PartialView("_ProduktyZKomentarzami", vm);
        }

        [HttpPost]
        public ActionResult ProduktyZKomentarzami(FiltrViewModel filtr)
        {
            vm.ListaProduktow = komentarzManager.PobierzKomentarzeZBazy(filtr);
            return PartialView("_ProduktyZKomentarzami", vm);
        }

        [ChildActionOnly]
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