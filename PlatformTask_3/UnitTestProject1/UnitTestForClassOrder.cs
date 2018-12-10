//-----------------------------------------------------------------------
// <copyright file="UnitTestForClassOrder.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
using System;
namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic;
    
    /// <summary>
    /// Tests for class <see cref="Order" />.
    /// </summary>
    [TestClass]
    public class UnitTestForClassOrder
    {
        /// <summary>
        /// Tests order without entrance.
        /// </summary>
        [TestMethod]
        public void Designer1_Test1_WithoutEntrance()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());

            Order first = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", carClassOrder1: CarClassOrder, time: "", entrance1: "", wihes: "");

            if (first.PhoneNumber != "+380981122333")
            {
                Assert.Fail();
            }
            if (first.Address1.City != "Lviv")
            {
                Assert.Fail();
            }
            if (first.Address1.Street != "Universytetcka")
            {
                Assert.Fail();
            }
            if (first.Address1.House != "1")
            {
                Assert.Fail();
            }
            if (first.Address1.Entrance != "")
            {
                Assert.Fail();
            }
            if (first.OrderID != id + 1)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests order with entrance.
        /// </summary>
        [TestMethod]
        public void Designer1_Test2_WithEntrance()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", carClassOrder1: CarClassOrder, time:"", entrance1: "3", wihes: "");
            if (first.PhoneNumber != "+380981122333")
            {
                Assert.Fail();
            }
            if (first.Address1.City != "Lviv")
            {
                Assert.Fail();
            }
            if (first.Address1.Street != "Universytetcka")
            {
                Assert.Fail();
            }
            if (first.Address1.House != "1")
            {
                Assert.Fail();
            }
            if (first.Address1.Entrance != "3")
            {
                Assert.Fail();
            }
            if (first.OrderID != id + 1)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests ID.
        /// </summary>
        [TestMethod]
        public void Designer1_Test3_ID()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order[] arr = new Order[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", carClassOrder1: CarClassOrder, time:"", entrance1: "3", wihes: "");
            }
            for (int i = 0; i < 5; i++)
            {
                if (arr[i].OrderID != id + 1 + i)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Tests car type.
        /// </summary>
        [TestMethod]
        public void Designer1_Test4_CarType()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", entrance1: "3", carClassOrder1: CarClassOrder, time: "", wihes: "");
            /*if (first.CarClassOrder != CarClass.Premium)
            {
                Assert.Fail();
            }*/
        }

        /// <summary>
        /// Tests designer of order without entrance.
        /// </summary>
        [TestMethod]
        public void Designer2_Test1_WithoutEntrance()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32", carClassOrder1: CarClassOrder, wihes: "");
            if (first.PhoneNumber != "+380981122333")
            {
                Assert.Fail();
            }
            if (first.Address1.City != "Lviv")
            {
                Assert.Fail();
            }
            if (first.Address1.Street != "Universytetcka")
            {
                Assert.Fail();
            }
            if (first.Address1.House != "1")
            {
                Assert.Fail();
            }
            if (first.Address1.Entrance != "")
            {
                Assert.Fail();
            }
            if (first.Address2.City != "Lviv1")
            {
                Assert.Fail();
            }
            if (first.Address2.Street != "Med.Pechery")
            {
                Assert.Fail();
            }
            if (first.Address2.House != "32")
            {
                Assert.Fail();
            }
            if (first.Address2.Entrance != "")
            {
                Assert.Fail();
            }
            if (first.OrderID != id + 1)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests designer of order with entrance.
        /// </summary>
        [TestMethod]
        public void Designer2_Test2_WithEntrance()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32", carClassOrder1: CarClassOrder, entrance1: "2", entrance2: "1", wihes: "");
            if (first.PhoneNumber != "+380981122333")
            {

                Assert.Fail();
            }
            if (first.Address1.City != "Lviv")
            {
                Assert.Fail();
            }
            if (first.Address1.Street != "Universytetcka")
            {
                Assert.Fail();
            }
            if (first.Address1.House != "1")
            {
                Assert.Fail();
            }
            if (first.Address1.Entrance != "2")
            {
                Assert.Fail();
            }
            if (first.Address2.City != "Lviv1")
            {
                Assert.Fail();
            }
            if (first.Address2.Street != "Med.Pechery")
            {
                Assert.Fail();
            }
            if (first.Address2.House != "32")
            {
                Assert.Fail();
            }
            if (first.Address2.Entrance != "1")
            {
                Assert.Fail();
            }
            if (first.OrderID != id + 1)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests ID.
        /// </summary>
        [TestMethod]
        public void Designer2_Test3_ID()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order[] arr = new Order[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32", carClassOrder1: CarClassOrder, entrance1: "2", entrance2: "1", wihes: "");
            }
            for (int i = 0; i < 5; i++)
            {
                if (arr[i].OrderID != id + 1 + i)
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Tests car type.
        /// </summary>
        [TestMethod]
        public void Designer2_Test4_CarType()
        {
            List<CarClass> CarClassOrder = new List<CarClass>();
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(phoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32", carClassOrder1: CarClassOrder, entrance1: "2", entrance2: "1", wihes: "");

            /*if (first.CarClassOrder != CarClass.Premium)
            {
                Assert.Fail();
            }*/
        }
    }
}