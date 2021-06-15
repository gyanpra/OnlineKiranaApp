using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineKirana.Models
{
    public class DeliveryAddress
    {
        [Key]
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public Nullable<int> CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<Order> OrderMaster { get; set; }
    }
}