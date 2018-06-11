using MTX_News.Models;
using MTX_News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTX_News.Infrastructure
{
    public class KomentarzManager
    {
        public void DodajKomentarz(Produkt vm)
        {
            string kod = vm.Kod;
            string komentarz = vm.Komentarz;
            int PozostalaLiczbaDniDoKoncaWaznosci = vm.PozostalaLiczbaDniDoKoncaWaznosci;
            string KtoWprowadzil = vm.KtoWprowadzil;
        }

        public void UsunKomentarz()
        {

        }
    }
}