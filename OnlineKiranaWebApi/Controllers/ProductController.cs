using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OnlineKirana.Models;
using OnlineKirana.Interface;
using OnlineKirana.DataAccessLayer;

namespace OnlineKirana.Controllers
{
    public class ProductController : ApiController
    {
        IProductRepository mydata = ProductDataAccessLayer.getRepository();

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return mydata.GetAllProducts();
        }

        public Product Get(int id)
        {
            return mydata.GetProductData(id);
        }

        [HttpPost]
        public Product Create(Product item)
        {
            return mydata.AddProduct(item);
        }

        [HttpPut]
        public bool Update(Product item)
        {
            return mydata.UpdateProduct(item);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            mydata.DeleteProduct(id);
        }
        
    }
}