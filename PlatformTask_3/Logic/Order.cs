using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logic
{
    [Serializable]
    public enum CarClass
    {   Standard,
        Econom,
        Premium,
        Elite,
        Universal,
        Minibus
    }
    public class Order
    {
        private bool IsFinalAddress = false;
        public static int ID;
        private int orderID;
        public int OrderID { get { return orderID; } set { orderID = ++ID; } }
        public string PhoneNumber { get; set; }
        public string ClientName { get; set; }
        public Address Address1 { get; set; }
        private Address address2;
        public Address Address2 { get { return address2; } set { address2 = value; IsFinalAddress = true; } }
        public string Wihes { get; set; }
        public List<CarClass> CarClassOrder { get; set; }
        static Order()
        {
            ID = 0;
        }
        public Order()
        {
            CarClassOrder = new List<CarClass>();
        }
        public Order(string PhoneNumber_, string city1, string street1, string house1, List<CarClass> carClassOrder1, string entrance1="", string wihes = "")
        {
            OrderID = 0;
            Address1 = new Address(city1, street1, house1,entrance1);
            Wihes = wihes;
            PhoneNumber = PhoneNumber_;
            CarClassOrder = carClassOrder1;
        }
        public Order(string PhoneNumber_, string city1, string street1, string house1, string city2, string street2, string house2, List<CarClass> carClassOrder1, string entrance1="",string entrance2="", string wihes = "")
        {
            OrderID = 0;
            Address1 = new Address(city1, street1, house1,entrance1);
            Address2 = new Address(city2, street2, house2,entrance2);
            Wihes = wihes;
            PhoneNumber = PhoneNumber_;
            CarClassOrder = carClassOrder1;
        }
        public Order(string name,string PhoneNumber_, Address a1,Address a2, List<CarClass> carClassOrder1, string wihes = "")
        {
            OrderID = 0;
            Address1 = a1;
            Address2 = a2;
            Wihes = wihes;
            ClientName = name;
            PhoneNumber = PhoneNumber_;
            CarClassOrder = carClassOrder1;
        }
        public override string ToString()
        {
            if (IsFinalAddress)
                return String.Format("Name: {0}, Phone: {1}, With: {2} to {3}, ClassCar: {4}, Wishes: {5};", ClientName, PhoneNumber, Address1, Address2, CarClassOrder, Wihes);
            return String.Format("Name: {0}, Phone: {1}, With: {2}, ClassCar: {4}, Wishes: {5};", ClientName, PhoneNumber, Address1, Address2, CarClassOrder, Wihes);

        }
    }

}

