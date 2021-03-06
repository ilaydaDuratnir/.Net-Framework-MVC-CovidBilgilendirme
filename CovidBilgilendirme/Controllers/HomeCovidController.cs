using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace CovidBilgilendirme.Controllers
{
    public class HomeCovidController : Controller
    {
        Context context = new Context();

        // GET: HomeCovid
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Rules()
        {
            var rule = context.Laws.First();
            return PartialView(rule);
        }

        public PartialViewResult Symptom()
        {
            var symptom = context.Symptoms.First();
            return PartialView(symptom);
        }

        public PartialViewResult News()
        {
            var question = context.Soru.OrderByDescending(x => x.SoruId).Take(5).ToList();
            return PartialView(question);
        }

        public PartialViewResult DoctorSay()
        {
            var advice = context.Database.SqlQuery<View_TavsiyeList>("SELECT * FROM View_TavsiyeList ").OrderByDescending(x=>x.TavsiyeId).Take(2).ToList();
            return PartialView(advice);
        }
        public PartialViewResult HowProtect()
        {
            var howProtection = context.Protections.ToList();
            return PartialView(howProtection);
        }

        public ActionResult CovidTable()
        {
            var covidDay = context.CovidTables.OrderByDescending(x => x.ID).First();

            ViewBag.SumNumberTest = context.CovidTables.Sum(i => i.NumberTest);
            ViewBag.SumNumberCase = context.CovidTables.Sum(i => i.NumberCase);
            ViewBag.SumNumberDeath = context.CovidTables.Sum(i => i.NumberDeath);
            ViewBag.SumNumberSeriouslyIll = context.CovidTables.Sum(i => i.NumberSeriouslyIll);
            ViewBag.SumNumberHealing = context.CovidTables.Sum(i => i.NumberHealing);

            return View(covidDay);
        }
    }
}