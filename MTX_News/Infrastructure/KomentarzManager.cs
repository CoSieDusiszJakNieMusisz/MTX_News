using MTX_News.Models;
using MTX_News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MTX_News.DAL;
using System.Data.SqlClient;
using System.Data;

namespace MTX_News.Infrastructure
{
    public class KomentarzManager : BaseQuery
    {
        KomentarzContext db;
        FiltrKomentarzy filtrKomentarzy;

        public KomentarzManager()
        {
            db = new KomentarzContext();
        }

        public IList<Produkt> PobierzKomentarzeZBazy(FiltrViewModel filtr)
        {
            filtrKomentarzy = new FiltrKomentarzy(filtr);
            return filtrKomentarzy.ZwrocListeKomentarzyUzytkownikowi();
        }

        public void DodajKomentarz(Produkt vm)
        {
            db.MB_MTX_DodajKomentarz(
                vm.Kod,
                vm.Nazwa,
                vm.Komentarz,
                vm.KtoWprowadzil,
                vm.PozostalaLiczbaDniDoKoncaWaznosci);
            
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

    class FiltrKomentarzy : BaseQuery
    {
        FiltrViewModel vm;

        public FiltrKomentarzy(FiltrViewModel filtr)
        {
            vm = filtr;
        }

        private DataTable PobierzKomentarzeZBazy()
        {
            string query = "exec CDN.MB_MTX_KomentarzeMtx @Kod = @filtr_kod, @Nazwa=@filtr_nazwa, @zKomentarzem = @filtr_zKomentarzem, @Producent = @filtr_producent";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.Add("@filtr_kod", SqlDbType.VarChar).Value = (vm.Kod == null) ? "%" : vm.Kod + "%";
            cmd.Parameters.Add("@filtr_nazwa", SqlDbType.VarChar).Value = (vm.Nazwa == null) ? "%" : "%" + vm.Nazwa + "%";
            cmd.Parameters.Add("@filtr_zKomentarzem", SqlDbType.Bit).Value = vm.ZawieraKomentarz;
            cmd.Parameters.Add("@filtr_producent", SqlDbType.VarChar).Value = (vm.Producent == null) ? "%" : "%" + vm.Producent + "%";
            DataTable dt = RunQuery(cmd);
            return dt;
        }

        public IList<Produkt> ZwrocListeKomentarzyUzytkownikowi()
        {
            List<Produkt> produkty = new List<Produkt>();
            DataTable tabelaZkomentarzami = PobierzKomentarzeZBazy();
            int i = 1;
            int iloscDni = 0;
            foreach(DataRow wierszZkomentarzem in tabelaZkomentarzami.Rows)
            {
                int.TryParse(wierszZkomentarzem[3].ToString(), out iloscDni);
                produkty.Add(
                    new Produkt
                    {
                        ProduktId = i,
                        Kod = wierszZkomentarzem[0].ToString(),
                        Nazwa = wierszZkomentarzem[1].ToString(),
                        Komentarz = wierszZkomentarzem[2].ToString(),
                        PozostalaLiczbaDniDoKoncaWaznosci = iloscDni,
                        KtoWprowadzil = wierszZkomentarzem[4].ToString(),
                        Producent = wierszZkomentarzem[5].ToString(),
                    }
                );
                i++;
            }
            return produkty;
        }
    }

}

