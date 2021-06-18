using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineKirana.Models;

namespace OnlineKirana.Models
{
    public class OnlineKiranaDbContext: DbContext
    {

        public OnlineKiranaDbContext() : base("OnlineKiranaConnectionString")
        {
        }
        public static OnlineKiranaDbContext Create()
        {
            return new OnlineKiranaDbContext();
        }

        public virtual DbSet<Admin> Admin { get; set; }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderMaster> OrderMaster { get; set; }
        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual DbSet<Image> Image { get; set; }

    }
}