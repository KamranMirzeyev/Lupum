using Lupum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lupum.DAL;
using System.Web.Helpers;

namespace Lupum.Controllers
{
    public class HomeController : Controller
    {
        private readonly LupumContext db = new LupumContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                Session["LoginError"] = "E-poçt və ya şifrə boş ola bilməz";
                return RedirectToAction("index");
            }

            User lgn = db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (lgn != null)
            {
                if (Crypto.VerifyHashedPassword(lgn.Password, user.Password))
                {
                    Session["Login"] = true;
                    Session["User"] = lgn;
                    return RedirectToAction("index","dashboard");
                }
            }

            Session["LoginError"] = "E-poçt və ya şifrə yalnışdır";
            return RedirectToAction("index");
        }
    }
}