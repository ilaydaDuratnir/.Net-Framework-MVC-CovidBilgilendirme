using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidBilgilendirme.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: News
        Context context = new Context();
        public ActionResult Index()
        { 
            List<Soru> soru = context.Soru.ToList();
            return View(soru);
        }
    }
}