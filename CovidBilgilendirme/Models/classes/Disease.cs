using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Disease
    {
        [Key]
        public int ID { get; set; }
        public string ChronicLung { get; set; } = "Hayır";
        public string Diabetes { get; set; } = "Hayır";
        public string Hypertension { get; set; } = "Hayır";
        public string ChronicLiver { get; set; } = "Hayır";
        public string Chemotherapy { get; set; } = "Hayır";
        public int TesterId { get; set; }
        public virtual Tester Tester { get; set; }
    }
}