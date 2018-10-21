using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp1
{
    [Serializable]
   public class Ellipse1
    {
        public Ellipse1()
        {
            Name = "";
        }
        public Ellipse1(string s)
        {
            Name = s;
        }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Name { get; set; }
        public double LeftProperty { get; set; }
        public double TopProperty { get; set; }
        public string br { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte A { get; set; }
        public Ellipse Draw()
        {
            Ellipse elipse = new Ellipse();
            elipse.Stroke = Brushes.Black;
            elipse.StrokeThickness = 5;
            elipse.SetValue(Canvas.LeftProperty, LeftProperty);
            elipse.SetValue(Canvas.TopProperty, TopProperty);
            elipse.Height = Height;
            elipse.Width = Width;
            elipse.Fill = new SolidColorBrush(Color.FromArgb(A, Red, Green, Blue));
            return elipse;
        }


    }
}
