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

        private IList<Produkt> PobierzProduktyByKod(FiltrViewModel filtr)
        {
            List<Produkt> produkty;
            produkty = (from x in db.MB_MtxNews
                        where x.MtN_Stan == (int)StatusyKomentarzy.AktywnyKomentarz && x.MtN_TwrKod.StartsWith(filtr.Kod)
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

        private IList<Produkt> PobierzProduktyByNazwa(FiltrViewModel filtr)
        {
            List<Produkt> produkty;
            produkty = (from x in db.MB_MtxNews
                        where x.MtN_Stan == (int)StatusyKomentarzy.AktywnyKomentarz && (x.MtN_TwrNazwa.Contains(filtr.Nazwa))
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

        private IList<Produkt> PobierzProduktyByKodAndNazwa(FiltrViewModel filtr)
        {
            List<Produkt> produkty;
            produkty = (from x in db.MB_MtxNews
                        where x.MtN_Stan == (int)StatusyKomentarzy.AktywnyKomentarz 
                        && (x.MtN_TwrKod.StartsWith(filtr.Kod) && x.MtN_TwrNazwa.Contains(filtr.Nazwa))
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
            List<Produkt> produkty;

            if (filtr.Kod==null && filtr.Nazwa!=null)
            {
                produkty = PobierzProduktyByNazwa(filtr).ToList();
            }
            else if (filtr.Kod!=null && filtr.Nazwa==null)
            {
                produkty = PobierzProduktyByKod(filtr).ToList();
            }
            else
            {
                produkty = PobierzProduktyByKodAndNazwa(filtr).ToList();
            }            
            return produkty;
        }

        public IList<Produkt> PobierzKomentarzeZBazy()
        {
            var produkty = Pobierz();
            return produkty;
        }

        public IList<Produkt> PobierzKomentarzeZBazy(FiltrViewModel filtr)
        {
            IList<Produkt> produkty;
            if (filtr.Kod == null && filtr.Nazwa == null)
                produkty = Pobierz();
            else                
                produkty = Pobierz(filtr);

            return produkty;
        }

        public void DodajKomentarz(Produkt vm)
        {
            MB_MtxNews mB_MtxNews = (from x in db.MB_MtxNews
                                     where x.MtN_ID == vm.ProduktId
                                     select x).First();
            mB_MtxNews.MtN_Komentarz = vm.Komentarz;
            mB_MtxNews.MtN_IloscDni = (short)vm.PozostalaLiczbaDniDoKoncaWaznosci;
            mB_MtxNews.MtN_KtoWprowadzil = vm.KtoWprowadzil;
            db.SaveChanges();
        }

        public void ZmienStatusNaNieaktywny(int produktId)
        {
            MB_MtxNews mB_MtxNews = (from x in db.MB_MtxNews
                                     where x.MtN_ID == produktId
                                     select x).First();
            mB_MtxNews.MtN_Stan = (int)StatusyKomentarzy.NieaktywnyKomentarz;
            db.SaveChanges();
        }
    }
}