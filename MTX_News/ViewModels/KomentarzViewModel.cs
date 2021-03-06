﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTX_News.ViewModels
{
    public class KomentarzViewModel 
    {
        public string Kod { get; set; }
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Wprowadź komentarz !")]
        [StringLength(100)]
        public string Komentarz { get; set; }

        [Required(ErrorMessage = "Podaj liczbę dni ważności komentarza !")]
        [Range(1,90)]
        public int PozostalaLiczbaDniDoKoncaWaznosci { get; set; }

        [Required(ErrorMessage = "Podpisz się !")]
        [StringLength(50)]
        public string KtoWprowadzil { get; set; }
    }
}