using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Table
    {
        [Key]

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TcNo { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int BirthYear { get; set; }
    }
}