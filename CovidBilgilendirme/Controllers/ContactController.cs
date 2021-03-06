using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using CovidBilgilendirme.Models.classes;
using System.Data.SqlClient;

namespace CovidBilgilendirme.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public void IletisimOlustur(Iletisim iletisim)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                           SecurityProtocolType.Tls11 |
                           SecurityProtocolType.Tls12;


            context.Database.ExecuteSqlCommand("IletisimOlustur @Isim, @Konu, @Email, @Mesaj", new SqlParameter("Isim", iletisim.Isim), new SqlParameter("Konu", iletisim.Konu), new SqlParameter("Email", iletisim.Email), new SqlParameter("Mesaj", iletisim.Mesaj));
            context.SaveChanges();

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("michelfarthe@gmail.com");
            mail.To.Add("michelfarthe@gmail.com");
            mail.Subject = iletisim.Konu;
            mail.IsBodyHtml = true;
            mail.Body = "eposta:" + iletisim.Email + "</br>" + "Mesaj:" + iletisim.Mesaj;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("michelfarthe@gmail.com", "michelfarthe123");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }


        [HttpPost]
        public ActionResult IletisimEkle(Iletisim iletisim)
        {
            Cevap cevap = new Cevap();
            try
            {
                IletisimOlustur(iletisim);
                cevap.Durum = 1;
                return Json(cevap);
            }
            catch (Exception ex)
            {
                cevap.Durum = 0;
                cevap.Mesaj = ex.Message;
                return Json(cevap);
            }



        }
    }
}