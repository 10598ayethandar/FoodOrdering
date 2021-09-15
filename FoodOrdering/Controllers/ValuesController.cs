using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodOrdering.Models;

namespace FoodOrdering.Controllers
{
    public class ValuesController : ApiController
    {
        // GET: api/Values
        public IEnumerable<Food> Get()
        {
            using (DBModel dbmodel = new DBModel())
            {
                return dbmodel.Foods.ToList();
            }
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            using (DBModel dbmodel = new DBModel())
            {
                var entity = dbmodel.Foods.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with Id" + id.ToString() + "not found");
                }
            }
        }

        // POST: api/Values
        public HttpResponseMessage Post([FromBody]Food food)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    dbmodel.Foods.Add(food);
                    dbmodel.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, food);
                    message.Headers.Location = new Uri(Request.RequestUri + food.Id.ToString());
                    return message;
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Values/5
        public HttpResponseMessage Put(int id, [FromBody]Food food)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    var dbmodels = dbmodel.Foods.FirstOrDefault(e => e.Id == id);
                    if (dbmodels == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with Id=" + id.ToString() + "not found to update");
                    }
                    else
                    {
                        dbmodels.Id = food.Id;
                        dbmodels.Name = food.Name;
                        dbmodels.Catagories = food.Catagories;
                        dbmodels.Price = food.Price;
                        dbmodels.ImagePath = food.ImagePath;
                        dbmodel.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, dbmodels);
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        // DELETE: api/Values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (DBModel dbmodel = new DBModel())
                {
                    var dbmodels = dbmodel.Foods.FirstOrDefault(e => e.Id == id);
                    if (dbmodels == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with Id=" + id.ToString() + "not found ot delete");

                    }
                    else
                    {
                        dbmodel.Foods.Remove(dbmodels);
                        dbmodel.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    
}
}
