using MTX_News.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTX_News.ViewModels
{
    public class ForumlarzKomentarzaViewModel
    {
        public int ProduktId { get; set; }
        public string Kod { get; set; }

        [Required(ErrorMessage = "Podaj ważność informacji.")]
        public int PozostalaLiczbaDniDoKoncaWaznosci { get; set; }

        [Required(ErrorMessage = "Dodaj komentarz.")]
        [StringLength(150)]
        public string Komentarz { get; set; }

        [Required(ErrorMessage = "Wpisz kto wprowadza komentarz.")]
        [StringLength(50)]
        public string KtoWprowadzil { get; set; }

        public IList<Produkt> ListaProduktow { get; set; }
    }
}