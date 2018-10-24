﻿using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;
using WpfApp1;
using System.Collections.Generic;
using System.IO;
using System.Windows;

using System.Windows.Data;
using System.Windows.Input;


using System.Xml.Serialization;
using Microsoft.Win32;

namespace WpfApp1.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void SetP1Test()
        {
            Point a = new Point();
            a.X = 0;
            a.Y = 10;
            Draw r = new Draw();
            r.SetP1(a);
            Assert.IsTrue(r.p1.X == 0 && r.p1.Y == 10);
        }
        //Треба пофіксити.Або видаліть.
        //[TestMethod()]
        //public void MousePressedTest()
        //{
        //    Draw a = new Draw();
        //    a.remap = true;
        //    a.MousePressed();
        //    Point p = Mouse.GetPosition(a.canvas);
        //    double left = double.Parse(a.current.GetValue(Canvas.LeftProperty).ToString()) + p.X - a.p1.X;

        //    Assert.IsTrue(a.arrSerz[a.arr.IndexOf(a.current)].LeftProperty == left && a.p1 == p);
        //}

        [TestMethod()]
        public void MousePressTest()
        {
            Draw a = new Draw();
            a.remap = false;
            a.MousePress();

            Assert.IsTrue(a.isMove == false);
        }

        [TestMethod()]
        public void RemapShapesTest()
        {
            Draw a = new Draw();
            a.RemapShapes(10);
            Assert.IsTrue(a.remap == true);
        }

        [TestMethod()]
        public void DrawOnCanvasTest()
        {
            Draw a = new Draw();
            Ellipse1 el = new Ellipse1();
            Ellipse elipse = el.Draw();
            a.DrawOnCanvas(el);

            Assert.IsTrue(a.last == elipse);
        }

        [TestMethod()]
        public void ReadFromFileTest()
        {
            Draw a = new Draw();
            a.ReadFromFile("File.txt");
            Assert.IsTrue(a.current == null && a.last == null);
        }

        [TestMethod()]
        public void DrawElipseTest()
        {
            Ellipse1 elipse1 = new Ellipse1();

            Draw a = new Draw();
            a.New();
            Point p1 = new Point();
            p1.X = 30;
            p1.Y = 10;

            Point p = new Point();
            p.X = 100;
            p.Y = 45;
            a.DrawElipse(p1, p, false);
            Assert.IsTrue(/*a.last.Stroke == Brushes.Black &&*/ a.last.Width == 70 && a.last.Height == 35);
        }
    }
}

namespace UnitTestTask2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DrawETest()
        {
            Ellipse1 elipse = new Ellipse1();
            
            Ellipse el = elipse.Draw();

            Assert.IsTrue(el.Stroke == Brushes.Black && el.StrokeThickness == 5);
        }
        [TestMethod]
        public void SetNameTest()
        {
            string name = "actual";
            Ellipse1 el = new Ellipse1(name);
            Assert.IsTrue(el.Name == "actual");
        }
        [TestMethod]
        public void NewTest()
        {
            Canvas cn = new Canvas();
            MenuItem mn = new MenuItem();
            MainWindow mm = new MainWindow();
            Draw d = new Draw(cn,mn,mm);
            d.New();
           
            Assert.IsTrue(d.arrSerz[0] == d.empty);

        }
        [TestMethod]
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
