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

        [Required(ErrorMessage="Podaj ważność informacji.")]        
        public int PozostalaLiczbaDniDoKoncaWaznosci { get; set; }

        [Required(ErrorMessage = "Dodaj komentarz.")]
        [StringLength(150)]
        public string Komentarz { get; set; }

        [Required(ErrorMessage = "Wpisz kto wprowadza komentarz.")]
        [StringLength(50)]
        public string KtoWprowadzil { get; set; }
    }
}