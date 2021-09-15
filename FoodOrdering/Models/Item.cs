using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodOrdering.Models
{
    public class Item
    {
        public Food food
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
    }
}