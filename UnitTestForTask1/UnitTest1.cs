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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace UnitTestForTask1
{
    /// <summary>
    /// Unit tests for the program.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests whether the program correctly writes and reads 
        /// <paramref>Name</paramref> and <paramref>Phone</paramref> from the file.
        /// </summary>
        [TestMethod]
        public void TestMethodForClassPhoneContact()
        {
            PhoneContact phone = new PhoneContact("Roman", "+3801234567");
            StreamWriter sw = new StreamWriter("FileForTest.txt");
            phone.WrtiteToFile(sw);
            sw.Close();
            PhoneContact phone1 = new PhoneContact();
            using (StreamReader sr = new StreamReader("FileForTest.txt"))
            {
                phone1.ReadFromFile(sr);
            }

            Assert.IsTrue(phone1.Name == "Roman," && phone1.Number == "+3801234567" && phone.Name == "Roman" && phone.Number == "+3801234567");
        }

        /// <summary>
        /// Tests whether the program correctly writes and reads 
        /// <paramref>Name</paramref> and <paramref>NicknameInSkype</paramref> from the file.
        /// </summary>
        [TestMethod]
        public void TestMethodForClassSkypeContact()
        {
            SkypeContact phone = new SkypeContact("Roman", "joni");
            StreamWriter sw = new StreamWriter("FileForTest.txt");
            phone.WrtiteToFile(sw);
            sw.Close();
            SkypeContact phone1 = new SkypeContact();
            using (StreamReader sr = new StreamReader("FileForTest.txt"))
            {
                phone1.ReadFromFile(sr);
            }
            
            Assert.IsTrue(phone1.Name == "Roman," && phone1.NicknameInSkype  == "joni" && phone.Name == "Roman" && phone.NicknameInSkype == "joni");
        }

        /// <summary>
        /// Tests whether the program correctly writes and reads 
        /// <paramref>Name</paramref> and <paramref>Email</paramref> from the file.
        /// </summary>
        [TestMethod]
        public void TestMethodForClassMailContact()
        {
            MailContact phone = new MailContact("Roman", "roman@gmail.com");
            StreamWriter sw = new StreamWriter("FileForTest.txt");
            phone.WrtiteToFile(sw);
            sw.Close();
            MailContact phone1 = new MailContact();
            using (StreamReader sr = new StreamReader("FileForTest.txt"))
            {
                phone1.ReadFromFile(sr);
            }

            Assert.IsTrue(phone1.Name == "Roman," && phone1.Email  == "roman@gmail.com" && phone.Name == "Roman" && phone.Email  == "roman@gmail.com");
        }
    }
}
