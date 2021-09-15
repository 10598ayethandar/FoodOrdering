using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FoodOrdering.Models;

namespace FoodOrdering.Controllers
{
    public class FrantEndController : Controller
    {
        // GET: FrantEnd
        public ActionResult Index()
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.ToList());
            }
        }
    }
}