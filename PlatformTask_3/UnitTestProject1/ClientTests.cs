using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{

    [TestClass]
    class ClientTests
    {
        [TestMethod]
        public void NameTest()
        {
            string expectedName = "Ira";

            Client client = new Client("Ira", "977797");
            Assert.IsTrue(client.Name == expectedName);
        }

        [TestMethod]
        public void PhoneTest()
        {
            string expectedPhone = "977797";

            Client client = new Client("Ira", "977797");
            Assert.IsTrue(client.Phone == expectedPhone);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            string expectedName = "Ira";
            string expectedPhone = "977797";

            Client client = new Client("Ira", "977797");
            Assert.IsTrue(client.Name == expectedName && client.Phone == expectedPhone);
        }
    }
}
