using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;
using WpfApp1;
namespace UnitTestTask2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DrawTest()
        {
            Ellipse1 elipse = new Ellipse1();
            
            Ellipse el = elipse.Draw();
            
            Assert.IsTrue(el.Stroke==Brushes.Black&&el.StrokeThickness==5);
        }
        public void SetNameTest()
        {
            string name = "actual";
            Ellipse1 el = new Ellipse1(name);
            Assert.IsTrue(el.Name == "actual");
        }

    }
}
