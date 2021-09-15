namespace FoodOrdering.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;

    public partial class OrderingcartModel
    {
        private List<Food> food;
        public OrderingcartModel()
        {
            DBModel dbmodel = new DBModel();
            this.food= dbmodel.Foods.ToList();
        }
        public List<Food> findAll()
        {
            return this.food;
        }
        public Food find(int? ID)
        {
            return this.food.Single(p => p.Id == ID);
        }


    }
}
