using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestForClassOrder
    {
        [TestMethod]
        public void Designer1_Test1_WithoutEntrance()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(name:"login1",PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1");
            if (first.PhoneNumber != "+380981122333")
                Assert.Fail();
            if (first.Address1.City != "Lviv")
                Assert.Fail();
            if (first.Address1.Street != "Universytetcka")
                Assert.Fail();
            if (first.Address1.House != "1")
                Assert.Fail();
            if (first.Address1.Entrance != "")
                Assert.Fail();
            if (first.OrderID != id + 1)
                Assert.Fail();

        }
        [TestMethod]
        public void Designer1_Test2_WithEntrance()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", entrance1: "3");
            if (first.PhoneNumber != "+380981122333")
                Assert.Fail();
            if (first.Address1.City != "Lviv")
                Assert.Fail();
            if (first.Address1.Street != "Universytetcka")
                Assert.Fail();
            if (first.Address1.House != "1")
                Assert.Fail();
            if (first.Address1.Entrance != "3")
                Assert.Fail();
            if (first.OrderID != id + 1)
                Assert.Fail();
        }
        [TestMethod]
        public void Designer1_Test3_ID()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order[] arr = new Order[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", entrance1: "3");
            }
            for (int i = 0; i < 5; i++)
            {
                if (arr[i].OrderID != id + 1 + i)
                    Assert.Fail();
            }

        }
        [TestMethod]
        public void Designer1_Test4_CarType()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", entrance1: "3",carClassOrder1:CarClass.Premium);
            if (first.CarClassOrder != CarClass.Premium)
                Assert.Fail();
        }


        [TestMethod]
        public void Designer2_Test1_WithoutEntrance()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1",city2:"Lviv1",street2:"Med.Pechery",house2:"32");
            if (first.PhoneNumber != "+380981122333")
                Assert.Fail();
            if (first.Address1.City != "Lviv")
                Assert.Fail();
            if (first.Address1.Street != "Universytetcka")
                Assert.Fail();
            if (first.Address1.House != "1")
                Assert.Fail();
            if (first.Address1.Entrance != "")
                Assert.Fail();
            if (first.Address2.City != "Lviv1")
                Assert.Fail();
            if (first.Address2.Street != "Med.Pechery")
                Assert.Fail();
            if (first.Address2.House != "32")
                Assert.Fail();
            if (first.Address2.Entrance != "")
                Assert.Fail();
            if (first.OrderID != id + 1)
                Assert.Fail();

        }
        [TestMethod]
        public void Designer2_Test2_WithEntrance()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32",entrance1:"2",entrance2:"1");
            if (first.PhoneNumber != "+380981122333")
                Assert.Fail();
            if (first.Address1.City != "Lviv")
                Assert.Fail();
            if (first.Address1.Street != "Universytetcka")
                Assert.Fail();
            if (first.Address1.House != "1")
                Assert.Fail();
            if (first.Address1.Entrance != "2")
                Assert.Fail();
            if (first.Address2.City != "Lviv1")
                Assert.Fail();
            if (first.Address2.Street != "Med.Pechery")
                Assert.Fail();
            if (first.Address2.House != "32")
                Assert.Fail();
            if (first.Address2.Entrance != "1")
                Assert.Fail();
            if (first.OrderID != id + 1)
                Assert.Fail();

        }
        [TestMethod]
        public void Designer2_Test3_ID()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order[] arr = new Order[5];
            for (int i = 0; i < 5; i++)
            {
                arr[i] = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32", entrance1: "2", entrance2: "1");
            }
            for (int i = 0; i < 5; i++)
            {
                if (arr[i].OrderID != id + 1 + i)
                    Assert.Fail();
            }

        }
        [TestMethod]
        public void Designer2_Test4_CarType()
        {
            int id = Int32.Parse(Order.ID.ToString());
            Order first = new Order(PhoneNumber_: "+380981122333", city1: "Lviv", street1: "Universytetcka", house1: "1", city2: "Lviv1", street2: "Med.Pechery", house2: "32", entrance1: "2", entrance2: "1",carClassOrder1:CarClass.Premium);
           
            if (first.CarClassOrder != CarClass.Premium)
                Assert.Fail();
        }

    }
}
