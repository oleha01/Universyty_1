//-----------------------------------------------------------------------
// <copyright file="Login1.xaml.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------

namespace PlatformTask_3
{
    using System.Windows;
    using Logic;

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Login when the button was clicked.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////Client cl = new Client("Roma", "Koltun", "Rom32", "222", "+380989233113", new Address("Lviv", "Horodozka", "5", "0"));
            Client cl = null;
            cl = Login.Users.Find(cl1 => 
            {
                if (cl1.Login == login.Text)
                {
                    return true;
                }

                return false;
            });
            if (cl != null && cl.Password == password.Text)
            {
                Window1 ww = new Window1(cl);
                this.Visibility = Visibility.Hidden;
                ww.ShowDialog();
                this.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Не вірний логін, або пароль");
            }
        }

        /// <summary>
        /// Hide this window and show registration window.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reg f = new Reg();
            this.Visibility = Visibility.Hidden;
            f.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}