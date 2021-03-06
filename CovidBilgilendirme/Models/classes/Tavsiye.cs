using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    [Table("Tavsiye")]
    public class Tavsiye
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TavsiyeId { get; set; }
        [Required, MaxLength]
        public string TavsiyeIcerik { get; set; }

        [Required, StringLength(500)]
        public string TavsiyeBalik { get; set; }

        [ForeignKey("DoktorId")]
        public Doktor Doktor { get; set; }

        public int DoktorId { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
    }
}