using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Cevap
    {
        public int Durum { get; set; }
        public object Veri { get; set; }
        public string Mesaj { get; set; }
    }
}