using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Task1;
namespace UnitTestForTask1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodForClassPhoneContact()
        {
            PhoneContact phone = new PhoneContact("Roman", "+3801234567");
            StreamWriter sw = new StreamWriter("FileForTest.txt");
            phone.WrtiteToFile(sw);
            sw.Close();
            StreamReader sr = new StreamReader("FileForTest.txt");
            PhoneContact phone1 = new PhoneContact();
            phone1.ReadFromFile(sr);
            Assert.IsTrue(phone1.Name == "Roman," && phone1.Number == "+3801234567" && phone.Name == "Roman" && phone.Number == "+3801234567");
        }
    }
}
