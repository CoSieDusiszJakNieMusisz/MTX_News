using MTX_News.Models;
using MTX_News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTX_News.DAL;

namespace MTX_News.Infrastructure
{
    public class KomentarzManager
    {
        KomentarzContext db;

        public KomentarzManager()
        {
            db = new KomentarzContext();            
        }

        public void PobierzKomentarzeZBazy()
        {

        }

        public void DodajKomentarz(Produkt vm)
        {
            string kod = vm.Kod;
            string komentarz = vm.Komentarz;
            int PozostalaLiczbaDniDoKoncaWaznosci = vm.PozostalaLiczbaDniDoKoncaWaznosci;
            string KtoWprowadzil = vm.KtoWprowadzil;
        }


    }
}