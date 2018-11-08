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
namespace WpfApp1.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Xml.Serialization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Win32;
    using Task_2;
    using WpfApp1;

    /// <summary>
    /// Class that containts unit tests.
    /// </summary>
    ////[TestClass()]
    public class UnitTest1
    {
        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod()]
        public void SetP1Test()
        {
            Point a = new Point();
            a.X = 0;
            a.Y = 10;
            Draw r = new Draw();
            r.SetP1(a);
            Assert.IsTrue(r.p1.X == 0 && r.p1.Y == 10);
        }
        ////Треба пофіксити.Або видаліть.
        ////[TestMethod()]
        ////public void MousePressedTest()
        ////{
        ////    Draw a = new Draw();
        ////    a.remap = true;
        ////    a.MousePressed();
        ////    Point p = Mouse.GetPosition(a.canvas);
        ////    double left = double.Parse(a.current.GetValue(Canvas.LeftProperty).ToString()) + p.X - a.p1.X;

        ////    Assert.IsTrue(a.arrSerz[a.arr.IndexOf(a.current)].LeftProperty == left && a.p1 == p);
        ////}

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod()]
        public void MousePressTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw a = new Draw(cn, mn, mm);
            a.remap = false;
            a.MousePress();

            Assert.IsTrue(a.isMove == false);
        }

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod()]
        public void RemapShapesTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw a = new Draw(cn, mn, mm);
            a.RemapShapes(10);
            Assert.IsTrue(a.remap == true && a.current == a.arr[10]);
        }

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod()]
        public void DrawOnCanvasTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw a = new Draw(cn, mn, mm);
            Ellipse1 el = new Ellipse1();
            Ellipse elipse = el.Draw();
            a.DrawOnCanvas(el);

            Assert.IsTrue(a.last == elipse);
        }

        /// <summary>
        /// Tests whether reading from file works correctly.
        /// </summary>
        ////[TestMethod()]
        public void ReadFromFileTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw a = new Draw(cn, mn, mm);
            
            a.ReadFromFile("File.txt");
            Assert.IsTrue(a.current == null && a.last == null);
        }

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod()]
        public void DrawElipseTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw a = new Draw(cn, mn, mm);
            Ellipse1 elipse1 = new Ellipse1();
            
            a.New();
            Point p1 = new Point();
            p1.X = 30;
            p1.Y = 10;

            Point p = new Point();
            p.X = 100;
            p.Y = 45;
            a.DrawElipse(p1, p, false);
            Assert.IsTrue(a.last.Stroke == Brushes.Black /*&& a.last.Width == 70 && a.last.Height == 35*/);
        }

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod]
        public void DrawETest()
        {
            Ellipse1 elipse = new Ellipse1();
            
            Ellipse el = elipse.Draw();

            Assert.IsTrue(el.Stroke == Brushes.Black && el.StrokeThickness == 5);
        }

        /// <summary>
        /// Tests whether setting a name works correctly.
        /// </summary>
        ////[TestMethod]
        public void SetNameTest()
        {
            string name = "actual";
            Ellipse1 el = new Ellipse1(name);
            Assert.IsTrue(el.Name == "actual");
        }

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod]
        public void NewTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw d = new Draw(cn, mn, mm);
            d.New();
           
            Assert.IsTrue(d.arrSerz[0] == d.empty);
        }

        /// <summary>
        /// Tests whether drawing works correctly.
        /// </summary>
        ////[TestMethod]
        public void DrawTest()
        {
            Canvas c = new Canvas();
            c.Width = 100;
            MenuItem m = new MenuItem();
            m.Width = 100;
            MainWindow w = new MainWindow();
            w.Width = 100;
            Draw a = new Draw(c, m, w);
            
            Assert.IsTrue(a.canvas.Width == 100 && a.shapesMenu.Width == 100 && a.window.Width == 100);
        }
    }
}
