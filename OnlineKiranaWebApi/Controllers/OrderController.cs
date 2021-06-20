using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineKirana.DataAccessLayer;
using OnlineKirana.Interface;
using OnlineKirana.Models;

namespace OnlineKirana.Controllers
{
    public class OrderController : ApiController
    {
        IOrderRepository mydata = OrderDataAccessLayer.getRepository();

        [HttpPost]
        [Route("AddToCart/{ProductID}")]
        public void Post(Order item)
        {
            return;
        }
    }
}