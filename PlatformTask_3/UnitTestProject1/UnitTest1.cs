using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CityTest()
        {
            string expectedCity = "Lviv";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.City == expectedCity);
        }

        [TestMethod]
        public void StreetTest()
        {
            string expectedStreet = "Lybinska";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.Street == expectedStreet);
        }
        [TestMethod]
        public void HouseTest()
        {
            string expectedHouse = "14";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.House == expectedHouse);
        }
        [TestMethod]
        public void EntranceTest()
        {
            string expectedEntrance = "2";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.Entrance == expectedEntrance);
        }
    }
}
