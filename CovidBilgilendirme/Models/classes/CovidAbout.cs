using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class CovidAbout
    {
        [Key]
        public int ID { get; set; }
        public string CovidTitle { get; set; }
        public string CovidImageUrl { get; set; }
        public string CovidDescription { get; set; }
    }
}