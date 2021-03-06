using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class CovidTable
    {
        [Key]
        public int ID { get; set; }
        public int NumberTest { get; set; }
        public int NumberCase { get; set; }
        public int NumberDeath { get; set; }
        public int NumberHealing { get; set; }
        public int NumberSeriouslyIll { get; set; }
        public int RatePneumonia { get; set; }
    }
}