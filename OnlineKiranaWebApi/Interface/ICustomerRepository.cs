using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OnlineKirana.Models;

namespace OnlineKirana.Interface
{
    public interface ICustomerRepository
    {
        Customer AuthenticateUser(Customer LoginCredentials);
        int RegisterUser(Customer UserData);
        bool CheckUserAvailabity(string Username);

        bool isUserExists(int CustomerID);

    }
}
