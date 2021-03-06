using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Symptom
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string WarningTitle { get; set; }
        public string ImgUrl { get; set; }
        public string MostCommon { get; set; }
        public string Rare { get; set; }
        public string Serious { get; set; }
        public string WarningLetter { get; set; }
    }
}