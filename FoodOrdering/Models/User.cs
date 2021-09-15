namespace FoodOrdering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "User email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email format")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "User type is required")]
        [StringLength(100)]
        public string UserType { get; set; }
    }
}
