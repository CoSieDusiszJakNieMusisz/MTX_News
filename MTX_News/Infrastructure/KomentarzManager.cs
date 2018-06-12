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

        private IList<Produkt> Pobierz()
        {
            var produkty = (from x in db.MB_MtxNews
                            where x.MtN_Stan == 0
                            select new Produkt()
                            {
                                ProduktId = x.MtN_ID,
                                Kod = x.MtN_TwrKod,
                                Nazwa = x.MtN_TwrNazwa,
                                Komentarz = x.MtN_Komentarz,
                                PozostalaLiczbaDniDoKoncaWaznosci = x.MtN_IloscDni,
                                KtoWprowadzil = x.MtN_KtoWprowadzil
                            }).ToList();
            return produkty;
        }

        private IList<Produkt> Pobierz(FiltrViewModel filtr)
        {
            var produkty = (from x in db.MB_MtxNews
                            where x.MtN_Stan == (int)StatusyKomentarzy.AktywnyKomentarz 
                            && (x.MtN_TwrKod.StartsWith(filtr.Kod) || x.MtN_TwrNazwa.Contains(filtr.Nazwa))
                            select new Produkt()
                            {
                                ProduktId = x.MtN_ID,
                                Kod = x.MtN_TwrKod,
                                Nazwa = x.MtN_TwrNazwa,
                                Komentarz = x.MtN_Komentarz,
                                PozostalaLiczbaDniDoKoncaWaznosci = x.MtN_IloscDni,
                                KtoWprowadzil = x.MtN_KtoWprowadzil
                            }).ToList();
            return produkty;
        }

        public IList<Produkt> PobierzKomentarzeZBazy()
        {
            var produkty = Pobierz();
            return produkty;
        }

        public IList<Produkt> PobierzKomentarzeZBazy(FiltrViewModel filtr)
        {
            var produkty = Pobierz(filtr);
            return produkty;
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