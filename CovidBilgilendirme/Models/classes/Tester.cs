using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Tester
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int BirthYear { get; set; }
        public string Result { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<Disease> Diseases { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
    }
}