using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Law
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string WarningTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string WarningDescription { get; set; }
    }
}