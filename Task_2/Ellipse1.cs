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

    /// <summary>
    /// Elipse class.
    /// </summary>
    [Serializable]
   public class Ellipse1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse1" /> class.
        /// </summary>
        public Ellipse1()
        {
            this.Name = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ellipse1" /> class.
        /// </summary>
        /// <param name="s">Name of ellipse.</param>
        public Ellipse1(string s)
        {
            this.Name = s;
        }

        /// <summary>
        /// Gets or sets the heiht of ellipse.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets the width of ellipse.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the name of ellipse.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the left property of ellipse.
        /// </summary>
        public double LeftProperty { get; set; }

        /// <summary>
        /// Gets or sets the top property of ellipse.
        /// </summary>
        public double TopProperty { get; set; }

        /// <summary>
        /// Gets or sets the amount of red.
        /// </summary>
        public byte Red { get; set; }

        /// <summary>
        /// Gets or sets the amount of green.
        /// </summary>
        public byte Green { get; set; }

        /// <summary>
        /// Gets or sets the amount of blue.
        /// </summary>
        public byte Blue { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Draw new ellipes
        /// </summary>
        /// <returns>New ellipse.</returns>
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
