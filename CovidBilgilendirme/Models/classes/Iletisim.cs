using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IletisimId { get; set; }
        [StringLength(50)]
        public string Isim { get; set; }
        [StringLength(50)]
        public string Konu { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [MaxLength]
        public string Mesaj { get; set; }
    }
}