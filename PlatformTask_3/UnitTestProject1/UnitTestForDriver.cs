using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace UnitTestProject1
{
    /// <summary>
    /// Сводное описание для UnitTestForDriver
    /// </summary>
    [TestClass]
    public class UnitTestForDriver
    {
        public UnitTestForDriver()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
            
        }

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

        [TestMethod]
        public void Test_CarType()
        {
            int id = Int32.Parse(Driver.Id.ToString());
            
            Driver first = new Driver( name:"Hawan",  id, surname: "Neron",  carClassOrder1: CarClass.Premium);
            if (first.CarCl != CarClass.Premium)
                Assert.Fail();
            
        }
        [TestMethod]
        public void Test_Drive()
        {
            int id = Int32.Parse(Driver.Id.ToString());
            Driver first = new Driver(Name: "Hawan",id, surname: "Neron", carClassOrder1: CarClass.Premium);
            if (first.Name != "Hawan")
                Assert.Fail();
            if (first.SurName != "Neron")
                Assert.Fail();
            if (first.OrderID != id + 1)
                Assert.Fail();

        }
        
    }
}
