namespace FoodOrdering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="User name is required")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "User email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email format")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})[-.]?([0-9]{4})[-.]?([0-9]{3})$",ErrorMessage ="Not a valid phone number")]
        public int? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Booking date is required")]
        [Column(TypeName = "date")]
        public DateTime? DateOfRegistration { get; set; }
        [Required(ErrorMessage = "Booking time is required")]
        public TimeSpan? TimeOfRegistration { get; set; }
        [Required(ErrorMessage = "Number of guests is required")]
        public int? NumberOfGuest { get; set; }
    }
}
