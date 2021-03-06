using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidBilgilendirme.Models.classes
{
    [Table("Soru")]
    public class Soru
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SoruId { get; set; }
        [Required, StringLength(500)]
        public string SoruBaslik { get; set; }
        [Required, MaxLength]
        public string SoruIcerik { get; set; }
    }
}