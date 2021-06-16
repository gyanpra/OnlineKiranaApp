using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OnlineKirana.Interface;
using OnlineKirana.Models;

namespace OnlineKirana.DataAccessLayer
{
    public class CustomerDataAccessLayer: ICustomerRepository
    {
        readonly OnlineKiranaDbContext _dbContext;
        public CustomerDataAccessLayer(OnlineKiranaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer AuthenticateUser(Customer loginCredentials)
        {
            Customer customer = new Customer();

            var CustomerDetails = _dbContext.Customer.FirstOrDefault(
                u => u.FirstName == loginCredentials.FirstName && u.Password == loginCredentials.Password
                );

            if (CustomerDetails != null)
            {

                customer = new Customer
                {
                    FirstName = CustomerDetails.FirstName,
                    CustomerID = CustomerDetails.CustomerID,
                };
                return customer;
            }
            else
            {
                return CustomerDetails;
            }
        }

        public int RegisterUser(Customer UserData)
        {
            try
            {
                _dbContext.Customer.Add(UserData);
                _dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUserAvailabity(string userName)
        {
            string customer = _dbContext.Customer.FirstOrDefault(x => x.Email == userName)?.ToString();

            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isUserExists(int CustomerID)
        {
            string customer = _dbContext.Customer.FirstOrDefault(x => x.CustomerID == CustomerID)?.ToString();

            if (customer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}