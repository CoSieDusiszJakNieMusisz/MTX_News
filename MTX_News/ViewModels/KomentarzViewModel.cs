using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTX_News.ViewModels
{
    public class KomentarzViewModel
    {
        public int ProduktId { get; set; }
        public string Komentarz { get; set; }
        public int PozostalaLiczbaDniDoKoncaWaznosci { get; set; }
        public string KtoWprowadzil { get; set; }
    }
}