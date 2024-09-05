using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using ABC_Resturant.Model;

namespace ABC_Resturant.Database
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {


        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Querys> Queries { get; set; }
        public DbSet<Resturant> Resturants { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<TableBooking> TableBookings { get; set; }
        public DbSet<Review> Reviews { get; set; }









    }
}

