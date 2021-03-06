using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Test
    {
        [Key]
        public int ID { get; set; }
        public string City { get; set; }
        public string HealthWorker { get; set; }
        public string MedicalCenter { get; set; }
        public string Touch { get; set; }
        public string Fever { get; set; }
        public int TesterId { get; set; }
        public virtual Tester Tester { get; set; }
    }
}