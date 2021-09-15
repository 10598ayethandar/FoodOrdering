using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FoodOrdering.Models;
using PagedList;
using PagedList.Mvc;

namespace FoodOrdering.Controllers
{
    public class BackEndController : Controller
    {
        // GET: BackEnd
        public ActionResult Index(string search,int? page)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(m => m.Name.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        // GET: BackEnd/Details/5
        public ActionResult Details(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // GET: BackEnd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackEnd/Create
        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(food.ImageFile.FileName);
                string extension = Path.GetExtension(food.ImageFile.FileName);
                Random random = new Random();
                int randomNumber = random.Next(0, 1000);
                filename = filename + randomNumber.ToString() + extension;
                food.ImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                food.ImageFile.SaveAs(filename);


                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Foods.Add(food);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BackEnd/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: BackEnd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Food food)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Entry(food).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BackEnd/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                return View(dbmodel.Foods.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: BackEnd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection formcollection)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    Food food = dbmodel.Foods.Where(x => x.Id == id).FirstOrDefault();
                    dbmodel.Foods.Remove(food);
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
