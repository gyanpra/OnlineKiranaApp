using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineKirana.Models;

namespace OnlineKirana.Interface
{
    public interface IOrderRepository
    {
        void AddToCart(Order ProductID);
        //void RemoveFromCart(int ProductID);
        //int CountCartItem(int ProductID);



    }
}