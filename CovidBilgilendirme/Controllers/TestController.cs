using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CovidBilgilendirmeML.Model;

namespace CovidBilgilendirme.Controllers
{
    public class TestController : Controller
    {
        readonly Context context = new Context();
        // GET: Test
        [HttpGet]
        public ActionResult Index(int id = 0)
        {

            if (id != 0)
            {
                var test = context.Testers.Find(id);
                ViewBag.Sonuc = test.Result;
            }
                return View();
        }

        [HttpPost]
        public ActionResult Index(Tester tester, Test test, Disease disease, Complaint complaint, ModelInput input)
        {
            ViewBag.Result = "";
            input.Chemotheraphy = disease.Chemotherapy;
            input.ChronicLiver = disease.ChronicLiver;
            input.ChronicLung = disease.ChronicLung;
            input.Diabetes = disease.Diabetes;
            input.Hypertension = disease.Hypertension;

            input.FeverHour = complaint.FeverHour;
            input.Diearrhea = complaint.Diarrhea;
            input.RunnyNose = complaint.RunnyNose;
            input.ShortnesOfBreath = complaint.ShortnessOfBreath;
            input.Sorethrout = complaint.Sorethroat;

            var pred = ConsumeModel.Predict(input);
            ViewBag.Result = pred;
            tester.Result = ViewBag.Result.Prediction;

            context.Testers.Add(tester);
            context.SaveChanges();
            AddTest(test, tester.ID);
            AddDisease(disease, tester.ID);
            AddComplaint(complaint, tester.ID);

            return RedirectToAction("Index", new { id = tester.ID });
        }
        public ActionResult AddTest(Test test, int id)
        {
            test.TesterId = id;
            context.Tests.Add(test);
            context.SaveChanges();
            return RedirectToAction("Index", "Test");
        }
        public ActionResult AddDisease(Disease disease, int id)
        {
            disease.TesterId = id;
            context.Diseases.Add(disease);
            context.SaveChanges();
            return RedirectToAction("Index", "Test");
        }
        public ActionResult AddComplaint(Complaint complaint, int id)
        {
            complaint.TesterId = id;
            context.Complaints.Add(complaint);
            context.SaveChanges();
            return RedirectToAction("Index", "Test");
        }
    }
}