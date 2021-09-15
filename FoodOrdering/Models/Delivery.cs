namespace FoodOrdering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delivery")]
    public partial class Delivery
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "User email is required")]
        [StringLength(100)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-.]?([0-9]{4})[-.]?([0-9]{3})$", ErrorMessage = "Not a valid phone number")]
        public int? PhoneNumber { get; set; }
        [Required(ErrorMessage = "State name is required")]
        [StringLength(10)]
        public string StateName { get; set; }
        [Required(ErrorMessage = "City name is required")]
        [StringLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Township name is required")]
        [StringLength(100)]
        public string State { get; set; }
        [Required(ErrorMessage = "Zip code is required")]
        public int? Zipcode { get; set; }
    }
}
