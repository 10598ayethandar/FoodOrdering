using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodOrdering.Models;

namespace FoodOrdering.Controllers
{
    public class OrderingcartController : Controller
    {
        // GET: Orderingcart
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Order(int id)
        {
            OrderingcartModel productmodel = new OrderingcartModel();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { food = productmodel.find(id), Quantity = 1 });
                Session["cart"] = cart;
                Session["count"] = 1;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { food = productmodel.find(id), Quantity = 1 });
                }
                Session["cart"] = cart;

                Session["count"] = GetCount(cart);
            }
            return RedirectToAction("IndexDelivery","Menu");
        }
        public int GetCount(List<Item> cart)
        {
            int count = 0;
            foreach (Item item in cart)
            {
                count = count + item.Quantity;
            }
            return count;
        }
        [HttpGet]
        public ActionResult Remove(int? id)
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var str = cart.Find(item => item.food.Id == id);
                cart.Remove(str);
                Session["cart"] = cart;
                Session["count"] = GetCount(cart);
            }
            else
            {
                Session["count"] = 0;
                Session["cart"] = null;
            }
            return RedirectToAction("Index");

        }
        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].food.Id == id)
                    return i;
            return -1;
        }
    }
}