using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Employe
    {
        [Key]
        public int ID { get; set; }
        public string EmployeTitle { get; set; }
        [Required(ErrorMessage = "Lütfen Açıklama Giriniz")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        public string EmployeName { get; set; }
        [Required(ErrorMessage = "Lütfen Bir Meslek Giriniz")]
        public string EmployeJob { get; set; }
    }
}