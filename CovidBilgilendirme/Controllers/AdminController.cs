using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.IO;

namespace CovidBilgilendirme.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["Context"].ConnectionString);
        SqlCommand cmd = new SqlCommand();

        readonly Context _context = new Context();
        Cevap cevap = new Cevap();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HomeCovidTable()
        {
            var covidTable = _context.CovidTables.OrderByDescending(x => x.ID).ToList();
            return View(covidTable);
        }

        [HttpGet]
        public ActionResult AddTest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTest(CovidTable covidTable)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_AddGeneralTableTest";
                cmd.Parameters.Add("@numberTest", SqlDbType.Int).Value = covidTable.NumberTest;
                cmd.Parameters.Add("@numberCase", SqlDbType.Int).Value = covidTable.NumberCase;
                cmd.Parameters.Add("@numberDeath", SqlDbType.Int).Value = covidTable.NumberDeath;
                cmd.Parameters.Add("@numberHealing", SqlDbType.Int).Value = covidTable.NumberHealing;
                cmd.Parameters.Add("@numberIll", SqlDbType.Int).Value = covidTable.NumberSeriouslyIll;
                cmd.Parameters.Add("@numberPneumonia", SqlDbType.Int).Value = covidTable.RatePneumonia;
                cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                //404 sayfası
                return View();
            }

            finally
            {
                con.Close();
            }

            return RedirectToAction("HomeCovidTable", "Admin");
        }

        public ActionResult DeleteTest(int id)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_DeleteTest";
                cmd.Parameters.Add("@testId", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //404 Hata Sayfası
                return View();
            }

            finally
            {
                con.Close();
            }

            return RedirectToAction("HomeCovidTable");
        }

        public ActionResult GetTest(int id)
        {
            var test = _context.CovidTables.Find(id);
            return View("GetTest", test);
        }

        public ActionResult UpdateTest(CovidTable covidTable)
        {
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UpdateGeneralTableTest";
                cmd.Parameters.Add("@numberTest", SqlDbType.Int).Value = covidTable.NumberTest;
                cmd.Parameters.Add("@numberCase", SqlDbType.Int).Value = covidTable.NumberCase;
                cmd.Parameters.Add("@numberDeath", SqlDbType.Int).Value = covidTable.NumberDeath;
                cmd.Parameters.Add("@numberHealing", SqlDbType.Int).Value = covidTable.NumberHealing;
                cmd.Parameters.Add("@numberIll", SqlDbType.Int).Value = covidTable.NumberSeriouslyIll;
                cmd.Parameters.Add("@numberPneumonia", SqlDbType.Int).Value = covidTable.RatePneumonia;
                cmd.Parameters.Add("@testId", SqlDbType.Int).Value = covidTable.ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                // 404 Hata Sayfası
                return View();
            }

            finally
            {
                con.Close();
            }

            return RedirectToAction("HomeCovidTable", "Admin");
        }

        public ActionResult Rules()
        {
            var rule = _context.Laws.ToList();
            return View(rule);
        }

        public ActionResult GetRule(int id)
        {
            var updateRule = _context.Laws.Find(id);
            return View("GetRule", updateRule);
        }

        public ActionResult UpdateRules(Law rules, HttpPostedFileBase Image)
        {
            var updateRule = _context.Laws.Find(rules.ID);

            if (Image != null)
            {
                var imageName = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                Image.SaveAs(path);
                updateRule.Image = "/Content/images/" + imageName;
            }

            updateRule.Title = rules.Title;
            updateRule.Description = rules.Description;
            updateRule.WarningDescription = rules.WarningDescription;
            updateRule.WarningTitle = rules.WarningTitle;
            _context.SaveChanges();

            return RedirectToAction("Rules", "Admin");
        }

        public ActionResult Symptom()
        {
            var symptom = _context.Symptoms.First();
            return View(symptom);
        }

        public ActionResult GetSymptom(int id)
        {
            var updateSymptom = _context.Symptoms.Find(id);
            return View("GetSymptom", updateSymptom);
        }

        public ActionResult UpdateSymptom(Symptom symptom, HttpPostedFileBase ImgUrl)
        {

            try
            {
                var updateSymptom = _context.Symptoms.Find(symptom.ID);

                if (ImgUrl != null)
                {
                    var imageName = Path.GetFileName(ImgUrl.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                    ImgUrl.SaveAs(path);
                    updateSymptom.ImgUrl = "/Content/images/" + imageName;
                }

                con.Open();
                string sqlQuery = "UPDATE Symptoms SET Title = @title, WarningTitle = @warningTitle, ImgUrl = @imgUrl, MostCommon = @mostCommon, Rare = @rare, Serious = @serious, WarningLetter = @warningLetter WHERE ID = @id   ";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = symptom.Title;
                cmd.Parameters.Add("@warningTitle", SqlDbType.NVarChar).Value = symptom.WarningTitle;
                cmd.Parameters.Add("@imgUrl", SqlDbType.NVarChar).Value = updateSymptom.ImgUrl;
                cmd.Parameters.Add("@mostCommon", SqlDbType.NVarChar).Value = symptom.MostCommon;
                cmd.Parameters.Add("@rare", SqlDbType.NVarChar).Value = symptom.Rare;
                cmd.Parameters.Add("@serious", SqlDbType.NVarChar).Value = symptom.Serious;
                cmd.Parameters.Add("@warningLetter", SqlDbType.NVarChar).Value = symptom.WarningLetter;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = symptom.ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //404 Hata Sayfası
                return View();
            }

            finally
            {
                con.Close();
            }

            return RedirectToAction("Symptom", "Admin");
        }

        public ActionResult Protection()
        {
            var protection = _context.Protections.ToList();
            return View(protection);
        }

        public ActionResult GetProtection(int id)
        {
            var updateProtection = _context.Protections.Find(id);
            return View("GetProtection", updateProtection);
        }

        public ActionResult UpdateProtection(Protection protection, HttpPostedFileBase ImageUrl)
        {
            var updateProtection = _context.Protections.Find(protection.ID);

            if (ImageUrl != null)
            {
                var imageName = Path.GetFileName(ImageUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                ImageUrl.SaveAs(path);
                updateProtection.ImageUrl = "/Content/images/" + imageName;
            }

            updateProtection.Title = protection.Title; ;
            updateProtection.Description = protection.Description;
            _context.SaveChanges();

            return RedirectToAction("Protection", "Admin");
        }

        public ActionResult AboutUs()
        {
            var aboutUs = _context.AboutUs.First();
            return View(aboutUs);
        }

        public ActionResult GetAboutUs(int id)
        {
            var updateAboutUs = _context.AboutUs.Find(id);
            return View("GetAboutUs", updateAboutUs);
        }

        public ActionResult UpdateAboutUs(AboutUs aboutUs, HttpPostedFileBase ImageUrl)
        {
            var updateAboutUs = _context.AboutUs.Find(aboutUs.ID);

            if (ImageUrl != null)
            {
                var imageName = Path.GetFileName(ImageUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                ImageUrl.SaveAs(path);
                updateAboutUs.ImageUrl = "/Content/images/" + imageName;
            }

            updateAboutUs.Title = aboutUs.Title; ;
            updateAboutUs.Description = aboutUs.Description;
            _context.SaveChanges();

            return RedirectToAction("AboutUs", "Admin");
        }


        public ActionResult AboutCovid()
        {
            var aboutCovid = _context.CovidAbouts.First();
            return View(aboutCovid);
        }

        public ActionResult GetAboutCovid(int id)
        {
            var updateCovid = _context.CovidAbouts.Find(id);
            return View("GetAboutCovid", updateCovid);
        }

        public ActionResult UpdateAboutCovid(CovidAbout covidAbout, HttpPostedFileBase CovidImageUrl)
        {
            var updateAboutCovid = _context.CovidAbouts.Find(covidAbout.ID);

            if (CovidImageUrl != null)
            {
                var imageName = Path.GetFileName(CovidImageUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                CovidImageUrl.SaveAs(path);
                updateAboutCovid.CovidImageUrl = "/Content/images/" + imageName;
            }

            updateAboutCovid.CovidTitle = covidAbout.CovidTitle; ;
            updateAboutCovid.CovidDescription = covidAbout.CovidDescription;
            _context.SaveChanges();

            return RedirectToAction("AboutCovid", "Admin");
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employe employe, HttpPostedFileBase ImageUrl)
        {

            if (!ModelState.IsValid)
            {
                var model = new Employe
                {
                    EmployeName = employe.EmployeName,
                    EmployeJob = employe.EmployeJob,
                    Description = employe.Description
                };

                return View("AddEmployee", model);
            }


            if (ImageUrl != null)
            {
                var imageName = Path.GetFileName(ImageUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                ImageUrl.SaveAs(path);
                employe.ImageUrl = "/Content/images/" + imageName;
            }

            _context.Employes.Add(employe);
            _context.SaveChanges();

            return RedirectToAction("AboutEmployee", "Admin");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var deleteEmployee = _context.Employes.Find(id);
            _context.Employes.Remove(deleteEmployee);
            _context.SaveChanges();
            return RedirectToAction("AboutEmployee", "Admin");
        }

        public ActionResult AboutEmployee()
        {
            var employesAbout = _context.Employes.ToList();
            return View(employesAbout);
        }

        public ActionResult GetEmployee(int id)
        {
            var updateEmployee = _context.Employes.Find(id);
            return View("GetEmployee", updateEmployee);
        }

        public ActionResult UpdateEmployee(Employe employe, HttpPostedFileBase ImageUrl)
        {
            var updateEmployee = _context.Employes.Find(employe.ID);

            if (ImageUrl != null)
            {
                var imageName = Path.GetFileName(ImageUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images"), imageName);
                ImageUrl.SaveAs(path);
                updateEmployee.ImageUrl = "/Content/images/" + imageName;
            }

            updateEmployee.Description = employe.Description;
            updateEmployee.EmployeName = employe.EmployeName;
            updateEmployee.EmployeJob = employe.EmployeJob;
            _context.SaveChanges();

            return RedirectToAction("AboutEmployee", "Admin");
        }

        public ActionResult CovidTest()
        {
            var testers = _context.Testers.ToList();
            return View(testers);
        }

        public ActionResult DeleteTester(int id)
        {
            var tester = _context.Testers.Find(id);
            _context.Testers.Remove(tester);
            _context.SaveChanges();
            return RedirectToAction("CovidTest");
        }

        public ActionResult GetTester(int id)

        {
            var t = _context.Testers.Find(id);
            return View("GetTester", t);
        }

        public ActionResult UpdateTester(Tester tester)
        {

            var te = _context.Testers.Find(tester.ID);
            te.FirstName = tester.FirstName;
            te.LastName = tester.LastName;
            te.TcNo = tester.TcNo;
            te.BirthYear = tester.BirthYear;
            te.Email = tester.Email;
            te.Phone = tester.Phone;
            te.Result = tester.Result;
            _context.SaveChanges();

            return RedirectToAction("CovidTest");
        }

        public ActionResult TesterDetail(int id)
        {
            var testerId = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            var detail = _context.Database.SqlQuery<TesterDetail>("Exec sp_TesterDetail @id", testerId).FirstOrDefault();
            return View("TesterDetail", detail);

        }

        public ActionResult Tables()
        {
            Table_base table_Base = new Table_base();
            table_Base.Positives = _context.Database.SqlQuery<Table>("SELECT * FROM pozitifler").ToList();
            table_Base.Negatives = _context.Database.SqlQuery<Table>("SELECT * FROM negatifler").ToList();
            table_Base.TeenPositive = _context.Database.SqlQuery<Table>("SELECT * FROM yirmi_yas_alti_pozitifler").ToList();
            table_Base.OldPositive = _context.Database.SqlQuery<Table>("SELECT * FROM altmis_bes_yas_ustu_pozitifler").ToList();

            return View("Tables", table_Base);
        }

        public ActionResult SikcaSorulanSorular()
        {

            return View(_context.Soru.ToList());
        }

        [HttpPost]
        public ActionResult SoruCikar(int SoruId)
        {

            try
            {
                _context.Database.ExecuteSqlCommand("SoruCikar @SoruId", new SqlParameter("SoruId", SoruId));
                _context.SaveChanges();

                cevap.Durum = 1;

            }
            catch (Exception)
            {
                cevap.Durum = 0;
            }

            return Json(cevap);
        }

        [HttpPost]
        public ActionResult SoruEkle(Soru soru)
        {
            try
            {
                _context.Soru.Add(soru);
                _context.SaveChanges();

                cevap.Durum = 1;
                cevap.Veri = soru;
            }
            catch (Exception)
            {
                cevap.Durum = 0;
            }
            return Json(cevap);


        }
        [HttpPost]
        public ActionResult SoruDuzenle(Soru soru)
        {
            try
            {
                Soru updateSoru = _context.Soru.Where(x => x.SoruId == soru.SoruId).FirstOrDefault();
                updateSoru.SoruBaslik = soru.SoruBaslik;
                updateSoru.SoruIcerik = soru.SoruIcerik;
                _context.SaveChanges();
                cevap.Durum = 1;
                cevap.Veri = updateSoru;
            }
            catch (Exception)
            {
                cevap.Durum = 0;
            }
            return Json(cevap);
        }
        [HttpPost]
        public ActionResult TavsiyeCikar(int? TavsiyeId)
        {

            try
            {
                Tavsiye tavsiye = _context.Tavsiye.Where(x => x.TavsiyeId == TavsiyeId).FirstOrDefault();
                _context.Tavsiye.Remove(tavsiye);
                _context.SaveChanges();
                cevap.Durum = 1;

            }
            catch (Exception)
            {
                cevap.Durum = 0;
            }

            return Json(cevap);
        }

        [HttpPost]
        public ActionResult TavsiyeEkle(Tavsiye tavsiye)
        {
            try
            {
                _context.Configuration.LazyLoadingEnabled = true;
                tavsiye.Doktor = _context.Doktor.Where(x => x.DoktorId == tavsiye.DoktorId).FirstOrDefault();
                tavsiye.OlusturulmaTarihi = DateTime.Now;
                _context.Tavsiye.Add(tavsiye);

                _context.SaveChanges();
                cevap.Durum = 1;

                cevap.Veri = tavsiye;
            }
            catch (Exception)
            {
                cevap.Durum = 0;
            }
            return Json(cevap);


        }
        [HttpPost]
        public ActionResult TavsiyeDuzenle(Tavsiye tavsiye)
        {
            try
            {
                Tavsiye Yenitavsiye = _context.Tavsiye.Where(x => x.TavsiyeId == tavsiye.TavsiyeId).FirstOrDefault();
                Yenitavsiye.TavsiyeBalik = tavsiye.TavsiyeBalik;
                Yenitavsiye.TavsiyeIcerik = tavsiye.TavsiyeIcerik;
                Yenitavsiye.DoktorId = tavsiye.DoktorId;
                _context.SaveChanges();
                cevap.Durum = 1;
                cevap.Veri = Yenitavsiye;
            }
            catch (Exception)
            {
                cevap.Durum = 0;
            }
            return Json(cevap);


        }
        public ActionResult Tavsiyeler()
        {
            _context.Configuration.LazyLoadingEnabled = true;
            List<Tavsiye> tavsiyeListesi = _context.Tavsiye.ToList();
            foreach (Tavsiye tavsiye in tavsiyeListesi)
            {
                tavsiye.Doktor = _context.Doktor.Where(x => x.DoktorId == tavsiye.DoktorId).FirstOrDefault();
            }
            return View(tavsiyeListesi);
        }

        public ActionResult Iletisim()
        {

            return View(_context.Iletisim.ToList());
        }

    }
}