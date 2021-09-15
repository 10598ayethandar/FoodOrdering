namespace FoodOrdering.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerFeedback>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerFeedback>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerFeedback>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<CustomerFeedback>()
                .Property(e => e.Feedback)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Delivery>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Catagories)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserType)
                .IsUnicode(false);
        }
    }
}
