using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrdering.Models;

namespace FoodOrdering.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexPickup()
        {
            return View();

        }
        [HttpPost]
        public ActionResult IndexPickup(Delivery delivery)
        {

            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Deliveries.Add(delivery);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("IndexDelivery","Menu");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delivery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delivery(Delivery delivery)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Deliveries.Add(delivery);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("IndexDelivery","Menu");
            }
            catch
            {
                return View();
            }
        }
        
    }
}