namespace FoodOrdering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Web;

    [Table("Food")]
    public partial class Food
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Food catagories are required")]
        [StringLength(100)]
        public string Catagories { get; set; }
        [Required(ErrorMessage = "Food price is required")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "Food image is required")]
        [StringLength(100)]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        public int? Quantity { get; set; }
    }
}
