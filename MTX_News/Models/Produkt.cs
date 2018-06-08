using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTX_News.Models
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public int TwrNumer { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }     
        public int PozostalaLiczbaDniDoKoncaWaznosci { get; set; }
        public string Komentarz { get; set; }
        public string KtoWprowadzil { get; set; }
    }
}