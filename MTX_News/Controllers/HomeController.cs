using MTX_News.Models;
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

        [ChildActionOnly]
        public ActionResult ProduktyZKomentarzami()
        {
            Random rnd = new Random(10);

            List<Produkt> produkts = new List<Produkt>();
            for(int i=1;i<=2;i++)
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
            return PartialView("_ProduktyZKomentarzami", produkts);
        }
    }
}