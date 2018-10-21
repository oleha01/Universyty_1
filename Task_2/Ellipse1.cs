//-----------------------------------------------------------------------
// <copyright file="Ellipse1.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace WpfApp1
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    [Serializable]
   public class Ellipse1
    {
        public Ellipse1()
        {
            this.Name = string.Empty;
        }

        public Ellipse1(string s)
        {
            this.Name = s;
        }

        public double Height { get; set; }

        public double Width { get; set; }

        public string Name { get; set; }

        public double LeftProperty { get; set; }

        public double TopProperty { get; set; }

        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public byte A { get; set; }

        public Ellipse Draw()
        {
            Ellipse elipse = new Ellipse();
            elipse.Stroke = Brushes.Black;
            elipse.StrokeThickness = 5;
            elipse.SetValue(Canvas.LeftProperty, this.LeftProperty);
            elipse.SetValue(Canvas.TopProperty, this.TopProperty);
            elipse.Height = this.Height;
            elipse.Width = this.Width;
            elipse.Fill = new SolidColorBrush(Color.FromArgb(this.A, this.Red, this.Green, this.Blue));
            return elipse;
        }
    }
}
