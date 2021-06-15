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

        public virtual DbSet<Product> Product { get; set; }


    }
}