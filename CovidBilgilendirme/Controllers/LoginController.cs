using CovidBilgilendirme.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CovidBilgilendirme.Controllers
{
    public class LoginController : Controller
    {
        readonly Context _context = new Context();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var info = _context.Admins.FirstOrDefault
                ( x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                Session["UserName"] = info.UserName;

                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}