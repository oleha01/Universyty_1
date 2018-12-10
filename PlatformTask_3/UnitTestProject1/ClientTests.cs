//-----------------------------------------------------------------------
// <copyright file="ClientTests.cs" company="LNU">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for class <see cref="Client"/>
    /// </summary>
    [TestClass]
    public class ClientTests
    {
        /// <summary>
        /// Tests whether the name is right.
        /// </summary>
        [TestMethod]
        public void NameTest()
        {
            string expectedName = "Ira";

            Client client = new Client("Ira", "977797");
            Assert.IsTrue(client.Name == expectedName);
        }

        /// <summary>
        /// Tests whether the phone number is right.
        /// </summary>
        [TestMethod]
        public void PhoneTest()
        {
            string expectedPhone = "977797";

            Client client = new Client("Ira", "977797");
            Assert.IsTrue(client.Phone == expectedPhone);
        }

        /// <summary>
        /// Tests whether constructor works right.
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            string expectedName = "Ira";
            string expectedPhone = "977797";

            Client client = new Client("Ira", "977797");
            Assert.IsTrue(client.Name == expectedName && client.Phone == expectedPhone);
        }

        /// <summary>
        /// Tests whether full constructor works right.
        /// </summary>
        [TestMethod]
        public void FullConstructorTest()
        {
            string expectedName = "Antonina";
            string expectedLastName = "Ivanova";
            string expectedLogin = "LausDio";
            string expectedPassword = "10tinogu";
            string expectedPhone = "977797";

            Client client = new Client("Antonina", "Ivanova", "LausDio", "10tinogu", "977797", new Address("Lviv", "Martovycha", "10", "8"));
            Assert.IsTrue(client.Name == expectedName && expectedLastName == client.LastName && expectedLogin == client.Login && expectedPassword == client.Password && client.Phone == expectedPhone);
        }

        /// <summary>
        /// Tests whether conversion to string works right.
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            string expectedString = "Antonina, Ivanova, LausDio, 10tinogu, 977797";

            Client client = new Client("Antonina", "Ivanova", "LausDio", "10tinogu", "977797", new Address("Lviv", "Martovycha", "10", "8"));
            Assert.IsTrue(client.ToString() == expectedString);
        }

        /// <summary>
        /// Tests whether empty constructor works right.
        /// </summary>
        [TestMethod]
        public void ConstructorEmptyTest()
        {
            Client client = new Client();
            Assert.IsTrue(client.Name == string.Empty && client.Phone == string.Empty && client.LastName == string.Empty && client.Login == string.Empty && client.Password == string.Empty);
        }
    }
}