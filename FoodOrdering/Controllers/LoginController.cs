using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrdering.Models;
using PagedList;
using PagedList.Mvc;

namespace FoodOrdering.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (DBModel dbmodel = new DBModel())
            {
                var usr = dbmodel.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Delivery", "Delivery");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is woring......");
                }
            }
            return View();
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(User user)
        {
            using (DBModel dbmodel = new DBModel())
            {
                var usr = dbmodel.Users.Single(u => u.UserType == user.UserType && u.Password == user.Password);
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("Index", "BackEnd");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is woring......");
                }
            }
            return View();
        }
        public ActionResult Index(string search, int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Users.Where(m => m.UserName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 4));
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Users.Add(user);
                    dbmodel.SaveChanges();

                }
                ModelState.Clear();

                ViewBag.Message = user.UserName + " " + "successfully registered";

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Users.Where(x => x.Id == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    User user = dbmodel.Users.Where(x => x.Id == id).FirstOrDefault();
                    dbmodel.Users.Remove(user);
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
