using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineKirana.Models;

namespace OnlineKirana.Interface
{
    public interface IProductRepository
    {

        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        bool UpdateProduct(Product product);
        Product GetProductData(int productId);
        string DeleteProduct(int productId);
        List<Product> GetSimilarProducts(int productId);

    }
}