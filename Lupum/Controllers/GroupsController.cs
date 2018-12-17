using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lupum.DAL;

namespace Lupum.Controllers
{
    public class GroupsController : Controller
    {
        private readonly LupumContext db = new LupumContext();

        public ActionResult Index()
        {
            var Groups = db.Groups.Include("Users").ToList();
            return View(Groups);
        }

        public ActionResult Create()
        {
            var Actions = db.Actions.ToList();
            return View(Actions);
        }

        [HttpPost]
        public JsonResult Create(Models.Group Group)
        {
            if (Group == null)
            {
                return Json(new
                {
                    status = 402
                }, JsonRequestBehavior.AllowGet);
            }

            if (db.Groups.FirstOrDefault(g => g.Name == Group.Name) != null)
            {
                return Json(new
                {
                    status = 404,
                    message = "Bu adda qrup var"
                }, JsonRequestBehavior.AllowGet);
            }

            if (Group.Roles==null || Group.Roles.Count==0)
            {
                return Json(new
                {
                    status = 405,
                    message = "Səlahiyyətlərdən ən azı birini seçməlisiniz"
                }, JsonRequestBehavior.AllowGet);
            }

            db.Groups.Add(Group);
            db.SaveChanges();

            return Json(new
            {
                status = 200
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            Models.Group grp = db.Groups.Find(id);
            if (grp == null)
            {
                return HttpNotFound();
            }

            if (db.Users.Where(u=>u.GroupId==grp.Id).Count() != 0)
            {
                return HttpNotFound();
            }

            db.Groups.Remove(grp);
            db.SaveChanges();

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            Models.Group grp = db.Groups.Include("Roles").FirstOrDefault(g => g.Id == id);
            if (grp == null)
            {
                return HttpNotFound();
            }
            ViewBag.Actions = db.Actions.ToList(); 
            return View(grp);
        }
    }
}