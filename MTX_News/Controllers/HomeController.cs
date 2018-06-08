using MTX_News.Models;
using MTX_News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTX_News.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[ChildActionOnly]
        public ActionResult ProduktyZKomentarzami()
        {
            Random rnd = new Random(10);
            List<Produkt> produkts = new List<Produkt>();
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
                        KtoWprowadzil = "Operator " + i.ToString()
                    });
            }
            ForumlarzKomentarzaViewModel vm = new ForumlarzKomentarzaViewModel();
            vm.ListaProduktow = produkts;
            return PartialView("_ProduktyZKomentarzami", vm);
        }

        [HttpPost]
        public ActionResult ZapiszKomentarz(ForumlarzKomentarzaViewModel komentarz)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", komentarz);
            }
            else
            {
                return View("Index");
            }
        }  
        
        public ActionResult FormularzKomentarza(int produktId)
        {
            return PartialView();
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