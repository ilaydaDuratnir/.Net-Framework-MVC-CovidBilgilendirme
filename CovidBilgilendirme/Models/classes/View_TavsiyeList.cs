using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class View_TavsiyeList
    {  
        public int TavsiyeId { get; set; }
        public string TavsiyeIcerik { get; set; }
        public string TavsiyeBalik { get; set; }
        public string DoktorAdiSoyadi { get; set; }
        public string DoktorFotograf { get; set; }
    }
}