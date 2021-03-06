using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidBilgilendirme.Controllers
{
    public class AboutController : Controller
    {
        Context context = new Context();
        // GET: About
        public ActionResult Index()
        {
            var aboutUs = context.AboutUs.First();
            return View(aboutUs);
        }

        public PartialViewResult CovidAbout()
        {
            var covidAbout = context.CovidAbouts.First();
            return PartialView(covidAbout);
        }

        public PartialViewResult Employe()
        {
            var employes = context.Employes.ToList();
            return PartialView(employes);
        }
    }
}