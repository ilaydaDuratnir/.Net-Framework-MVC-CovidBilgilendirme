using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CovidBilgilendirme.Models.classes
{
    public class Context : DbContext
    {
        public DbSet<Protection> Protections { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Law> Laws { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<CovidAbout> CovidAbouts { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<CovidTable> CovidTables { get; set; }
        public DbSet<Tester> Testers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Soru> Soru { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Tavsiye> Tavsiye { get; set; }
        public List<View_TavsiyeList> TavsiyeList
        {
            get
            {
                return this.Database.SqlQuery<View_TavsiyeList>("select * from dbo.View_TavsiyeList").ToList();
            }
        }
       

    }
}