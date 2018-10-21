//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="LNU">
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
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Draw dr;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.dr = new Draw(canvas, shapesMenu, this);
        }

        private void ShapesMenu_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((sender as MenuItem).ToString());
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.dr.SetP1(Mouse.GetPosition(this.canvas));
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.dr.MousePress();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.dr.MousePressed();
            }
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            this.dr.New();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.dr.Read();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.dr.SaveFIle();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.dr.SaveAs();
        }
    }
}
