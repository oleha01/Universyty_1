//-----------------------------------------------------------------------
// <copyright file="Order.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace Logic
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The enumeration of different classes of cars.
    /// </summary>
    public enum CarClass
    {
        /// <summary>
        /// Standart class.
        /// </summary>
        Standard,

        /// <summary>
        /// Econom class.
        /// </summary>
        Econom,

        /// <summary>
        /// Premium class.
        /// </summary>
        Premium,

        /// <summary>
        /// Elite class.
        /// </summary>
        Elite,

        /// <summary>
        /// Universal car.
        /// </summary>
        Universal,

        /// <summary>
        /// Minibus car.
        /// </summary>
        Minibus
    }

    /// <summary>
    /// Encapsulates the information about the order.
    /// </summary>
    [Serializable]
    public class Order
    {
        /// <summary>
        /// New ID.
        /// </summary>
        public static int ID;

        /// <summary>
        /// Boolean that indicates whether this is the final address.
        /// </summary>
        private bool isFinalAddress = false;

        /// <summary>
        /// Order ID.
        /// </summary>
        private int orderID;

        /// <summary>
        /// Address of destination.
        /// </summary>
        private Address address2;

        /// <summary>
        /// Initializes static members of the <see cref="Order" /> class.
        /// </summary>
        static Order()
        {
            ID = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        public Order()
        {
            this.CarClassOrder = new List<CarClass>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="phoneNumber_">The user`s phone number.</param>
        /// <param name="city1">The name of the city.</param>
        /// <param name="street1">The name of the street.</param>
        /// <param name="house1">The number of the house.</param>
        /// <param name="carClassOrder1">The class of the car.</param>
        /// <param name="time">When the order was made.</param>
        /// <param name="entrance1">The number enterence.</param>
        /// <param name="wihes">The additional wishes to order.</param>
        public Order(string phoneNumber_, string city1, string street1, string house1, List<CarClass> carClassOrder1, string time, string entrance1 = "", string wihes = "")
        {
            this.OrderID = 0;
            this.Address1 = new Address(city1, street1, house1, entrance1);
            this.Wishes = wihes;
            this.PhoneNumber = phoneNumber_;
            this.CarClassOrder = carClassOrder1;
            this.Time = time;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="phoneNumber_">The user`s phone number.</param>
        /// <param name="city1">The name of the city.</param>
        /// <param name="street1">The name of the street.</param>
        /// <param name="house1">The number of the house.</param>
        /// <param name="city2">The name of the city of destination.</param>
        /// <param name="street2">The name of the street of destination.</param>
        /// <param name="house2">The number of the house of destination.</param>
        /// <param name="carClassOrder1">The class of the car.</param>
        /// <param name="entrance1">The number enterence.</param>
        /// <param name="entrance2">The number enterence of destination.</param>
        /// <param name="wihes">The additional wishes to order.</param>
        public Order(string phoneNumber_, string city1, string street1, string house1, string city2, string street2, string house2, List<CarClass> carClassOrder1, string entrance1 = "", string entrance2 = "", string wihes = "")
        {
            this.OrderID = 0;
            this.Address1 = new Address(city1, street1, house1, entrance1);
            this.Address2 = new Address(city2, street2, house2, entrance2);
            this.Wishes = wihes;
            this.PhoneNumber = phoneNumber_;
            this.CarClassOrder = carClassOrder1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="name">Name of the client.</param>
        /// <param name="phoneNumber_">The user`s phone number.</param>
        /// <param name="a1">Departure address.</param>
        /// <param name="a2">Destination address.</param>
        /// <param name="carClassOrder1">The class of the car.</param>
        /// <param name="time">The time when the order was made.</param>
        /// <param name="wihes">The additional wishes to order.</param>
        public Order(string name, string phoneNumber_, Address a1, Address a2, List<CarClass> carClassOrder1, string time, string wihes)
        {
            this.OrderID = 0;
            this.Address1 = a1;
            this.Address2 = a2;
            this.Wishes = wihes;
            this.ClientName = name;
            this.PhoneNumber = phoneNumber_;
            this.CarClassOrder = carClassOrder1;
            this.Time = time;
        }
        
        /// <summary>
        /// Gets or sets the time when the order was made.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        public int OrderID
        {
            get
            {
                return this.orderID;
            }

            set
            {
                this.orderID = ++ID;
            }
        }

        /// <summary>
        /// Gets or sets the user`s phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the client name.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets the client home address.
        /// </summary>
        public Address Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address of destination.
        /// </summary>
        public Address Address2
        {
            get
            {
                return this.address2;
            }

            set
            {
                this.address2 = value;
                this.isFinalAddress = true;
            }
        }

        /// <summary>
        /// Gets or sets additional wishes to order.
        /// </summary>
        public string Wishes { get; set; }

        /// <summary>
        /// Gets or sets the class of the car.
        /// </summary>
        public List<CarClass> CarClassOrder { get; set; }

        /// <summary>
        /// Shows the order information.
        /// </summary>
        /// <returns>Returns the order information as the string.</returns>
        public override string ToString()
        {
            if (this.isFinalAddress)
            {
                return string.Format("Name: {0}, Phone: {1}, With: {2} to {3}, ClassCar: {4}, Wishes: {5};", this.ClientName, this.PhoneNumber, this.Address1, this.Address2, this.CarClassOrder, this.Wishes);
            }

            return string.Format("Name: {0}, Phone: {1}, With: {2}, ClassCar: {4}, Wishes: {5};", this.ClientName, this.PhoneNumber, this.Address1, this.Address2, this.CarClassOrder, this.Wishes);
        }
    }
}