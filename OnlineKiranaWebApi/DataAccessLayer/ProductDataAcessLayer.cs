using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlineKirana.Interface;
using OnlineKirana.Models;


namespace OnlineKirana.DataAccessLayer
{
    public class ProductDataAccessLayer: IProductRepository
    {
        readonly OnlineKiranaDbContext _dbContext;

        public ProductDataAccessLayer(OnlineKiranaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Product> GetAllProducts()
        {
            try
            {
                return _dbContext.Product.AsNoTracking().ToList();
            }
            catch
            {
                throw;
            }
        }

        public int AddProduct(Product product)
        {
            try
            {
                _dbContext.Product.Add(product);
                _dbContext.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public int UpdateProduct(Product product)
        {
            try
            {
                Product oldProductData = GetProductData(product.ProductID);

                if (oldProductData.ProductImage != null)
                {
                    if (product.ProductImage == null)
                    {
                        product.ProductImage = oldProductData.ProductImage;
                    }
                }

                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public Product GetProductData(int productId)
        {
            try
            {
                Product product = _dbContext.Product.FirstOrDefault(x => x.ProductID == productId);
                if (product != null)
                {
                    _dbContext.Entry(product).State = EntityState.Detached;
                    return product;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public string DeleteProduct(int productId)
        {
            try
            {
                Product product = _dbContext.Product.Find(productId);
                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();

                return (product.ProductImage);
            }
            catch
            {
                throw;
            }
        }

        public List<Product> GetSimilarProducts(int productId)
        {
            List<Product> lstProduct = new List<Product>();
            Product product = GetProductData(productId);

            lstProduct = _dbContext.Product.Where(x => x.Category == product.Category && x.ProductID != product.ProductID)
                .OrderBy(u => Guid.NewGuid())
                .Take(5)
                .ToList();
            return lstProduct;
        }


    }
}