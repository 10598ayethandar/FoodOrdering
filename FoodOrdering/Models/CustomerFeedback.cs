namespace FoodOrdering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerFeedback")]
    public partial class CustomerFeedback
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100)]
      
        public string Name { get; set; }
        [Required(ErrorMessage = "User email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email format")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "User comment is required")]
        [StringLength(200)]
        public string Comment { get; set; }
       
        [StringLength(100)]
        public string Feedback { get; set; }
    }
}
