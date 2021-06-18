using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineKirana.Models
{
    public class OrderMaster
    {
        [Key]
        public int OrderMasterID { get; set; }
        public int OrderID { get; set; }
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public string OrderType { get; set; }

    }
}