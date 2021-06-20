using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlineKirana.Interface;
using OnlineKirana.Models;

namespace OnlineKirana.DataAccessLayer
{
    public class OrderDataAccessLayer : IOrderRepository
    {
        private OnlineKiranaDbContext _dbContext = new OnlineKiranaDbContext();
        private static OrderDataAccessLayer  repo = new OrderDataAccessLayer();
        public static IOrderRepository getRepository()
        { return repo; }

        public void AddToCart(Order productId)
        {
            _dbContext.Order.Add(productId);
            _dbContext.SaveChanges();

        }
    }
}