using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Driver
    {
        private bool IsFinalAddress = false;
        CarClass carcl { get; set; }
        public Address Address1 { get; set; }
        private Address address2;
        public Address Address2 { get { return address2; } set { address2 = value; IsFinalAddress = true; } }
        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set { }
        }
        public string Id
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set { }
        }
        public Driver(string n, string id, string city1, string street1, string house1,  string entrance1 = "",  CarClass car = CarClass.Econom)
        {
            Name = n;
            Id = id;
            Address1 = new Address(city1, street1, house1, entrance1);
            
            carcl = car;
        }
        public Driver(string n,string id, string city1, string street1, string house1, string city2, string street2, string house2, string entrance1 = "", string entrance2 = "", CarClass car = CarClass.Econom)
        {
            Name = n;
            Id = id;
            Address1 = new Address(city1, street1, house1, entrance1);
            Address2 = new Address(city2, street2, house2, entrance2);
            carcl = car;
        }
        public override string ToString()
        {
            if (IsFinalAddress)
                return String.Format("Name: {0}, With: {1} to {2}, ClassCar: {3};", Name,  Address1, Address2, carcl);
            return String.Format("Name: {0}, With: {1}, ClassCar: {2} ;", Name, Address1, Address2, carcl );

        }

    }
}
