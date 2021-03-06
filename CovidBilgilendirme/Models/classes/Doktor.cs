using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    [Table("Doktor")]
    public class Doktor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoktorId { get; set; }

        [StringLength(100)]
        public string DoktorAdiSoyadi { get; set; }

        public string DoktorFotograf { get; set; }
    }
}