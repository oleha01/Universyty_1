//-----------------------------------------------------------------------
// <copyright file="UnitTestForDriver.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------using System;
namespace UnitTestProject1
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic;
    
    /// <summary>
    /// Сводное описание для UnitTestForDriver
    /// </summary>
    [TestClass]
    public class UnitTestForDriver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTestForDriver" /> class.
        /// </summary>
        public UnitTestForDriver()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        /// <summary>
        /// Used to store information that is provided to unit tests.
        /// </summary>
        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        /// <summary>
        /// Tests car type.
        /// </summary>
        [TestMethod]
        public void Test_CarType()
        {
            Driver first = new Driver(n: "Hawan", id:"1", sur: "Neron", car: CarClass.Premium);
            if (first.CarCl != CarClass.Premium)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// Tests drive.
        /// </summary>
        [TestMethod]
        public void Test_Drive()
        {
            Driver first = new Driver(n: "Hawan", id:"2", sur: "Neron", car: CarClass.Premium);
            if (first.Name != "Hawan")
            {
                Assert.Fail();
            }
            if (first.SurName != "Neron")
            {
                Assert.Fail();
            }
        }
    }
}