using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CovidBilgilendirme.Controllers
{
    public class AdviceController : Controller
    {
        // GET: Advice
        public ActionResult Index()
        {
            Context db = new Context();
            List<View_TavsiyeList> tavsiyelist = db.TavsiyeList;
            return View(tavsiyelist);
        }
    }
}