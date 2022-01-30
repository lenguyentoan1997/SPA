using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpaLNT.Models.Spa
{
    public class SpaDbContext : DbContext
    {
        public SpaDbContext() : base("name=DefaultConnection") { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<UseService> UseServices { get; set; }
        public DbSet<OrderCustomer> OrderCustomers { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public DbSet<OrderProvider> OrderProviders { get; set; }
        public DbSet<ProviderOrderDetail> ProviderOrderDetails { get; set; }
    }
}