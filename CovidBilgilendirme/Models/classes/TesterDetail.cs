using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class TesterDetail
    {
        [Key]

        public string FeverHour { get; set; }

        public string ShortnessOfBreath { get; set; }

        public string Sorethroat { get; set; }

        public string RunnyNose { get; set; }

        public string Diarrhea { get; set; }

        public string ChronicLung { get; set; }

        public string Diabetes { get; set; }

        public string Hypertension { get; set; }

        public string ChronicLiver { get; set; }

        public string Chemotherapy { get; set; }

        public string City { get; set; }
        public string HealthWorker { get; set; }

        public string MedicalCenter { get; set; }
        public string Touch { get; set; }

        public string Fever { get; set; }
    }
}