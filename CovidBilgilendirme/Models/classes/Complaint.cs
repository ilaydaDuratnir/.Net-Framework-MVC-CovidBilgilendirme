using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Complaint
    {
        [Key]
        public int ID { get; set; }
        public string FeverHour { get; set; } = "Hayır";
        public string ShortnessOfBreath { get; set; } = "Hayır";
        public string Sorethroat { get; set; } = "Hayır";
        public string RunnyNose { get; set; } = "Hayır";
        public string Diarrhea { get; set; } = "Hayır";
        public int TesterId { get; set; }
        public virtual Tester Tester { get; set; }
    }
}