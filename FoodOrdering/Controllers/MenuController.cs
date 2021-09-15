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
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }
        public ActionResult IndexDelivery(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }
    }
}