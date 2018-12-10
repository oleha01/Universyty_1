//-----------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace UnitTestProject1
{
    using System;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for class <see cref="Address"/>
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests whether city is right.
        /// </summary>
        [TestMethod]
        public void CityTest()
        {
            string expectedCity = "Lviv";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.City == expectedCity);
        }

        /// <summary>
        /// Tests whether street is right.
        /// </summary>
        [TestMethod]
        public void StreetTest()
        {
            string expectedStreet = "Lybinska";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.Street == expectedStreet);
        }

        /// <summary>
        /// Tests whether house number is right.
        /// </summary>
        [TestMethod]
        public void HouseTest()
        {
            string expectedHouse = "14";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.House == expectedHouse);
        }

        /// <summary>
        /// Tests whether entrance number is right.
        /// </summary>
        [TestMethod]
        public void EntranceTest()
        {
            string expectedEntrance = "2";
            Address route = new Address("Lviv", "Lybinska", "14", "2");

            Assert.IsTrue(route.Entrance == expectedEntrance);
        }

        /// <summary>
        /// Tests whether constructor works right.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            string expectedCity = "Lviv";
            string expectedStreet = "Lybinska";
            string expectedHouse = "14";
            string expectedEntrance = "2";

            Address route = new Address("Lviv", "Lybinska", "14", "2");
            Assert.IsTrue(route.City == expectedCity && route.Street == expectedStreet && route.House == expectedHouse && route.Entrance == expectedEntrance);
        }

        /// <summary>
        /// Tests whether empty constructor works right.
        /// </summary>
        [TestMethod]
        public void ConstructorEmptyTest()
        {
            Address route = new Address();
            Assert.IsTrue(route.City == string.Empty && route.Street == string.Empty && route.House == string.Empty);
        }
    }
}