//-----------------------------------------------------------------------
// <copyright file="Reg.xaml.cs" company="LNU">
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Reg" /> class.
        /// </summary>
        public Reg()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Saves information about client.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Client c;
            if (profile_phone_Password.Text == profile_phone_password2.Text && profile_phone_Password.Text.Length > 4)
            {
                c = new Client(profile_firstname.Text, profile_lastname.Text, profile_phone_login.Text, profile_phone_Password.Text, profile_phone.Text, new Address(profile_phone_sity.Text, profile_phone_adres.Text, profile_phone_Dom.Text, profile_phone_Entran.Text));
                Login.bs.Clients.Add(c);
                Login.bs.SaveChanges();
            }
            else
            {
                MessageBox.Show("Пароль не співпадають, або коротші ніж 4 символи");
            }
        }
    }
}
