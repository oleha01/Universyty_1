using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Task_2
{
    [Serializable]
   public class Ellipse1
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double LeftProperty { get; set; }
        public double TopProperty { get; set; }
        public string br { get; set; }
        public Ellipse Draw()
        {
            Ellipse elipse = new Ellipse();
            
            elipse.Stroke = Brushes.Black;
            elipse.SetValue(Canvas.LeftProperty, LeftProperty);
            elipse.SetValue(Canvas.TopProperty, TopProperty);
            elipse.Height = Height;
            elipse.Width = Width;
            return elipse;
        }


    }
}
