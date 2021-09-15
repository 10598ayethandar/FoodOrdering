using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrdering.Models;

namespace FoodOrdering.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(CustomerFeedback feedback)
        {
            try
            {   
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.CustomerFeedbacks.Add(feedback);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index","FrantEnd");
            }
            catch
            {
                return View();
            }
        }
    }
}