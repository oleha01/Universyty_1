using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    class Order
    {

        public static int ID;

        private bool isFinalAddress = false;

        private int orderID;

        private Address address2;
        public string Time { get; set; }
  
        public string PhoneNumber { get; set; }

        public string ClientName { get; set; }

        public Address Address1 { get; set; }
        public string Wishes { get; set; }
    }
}
