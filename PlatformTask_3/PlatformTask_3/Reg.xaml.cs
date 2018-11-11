using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Logic;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlatformTask_3
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Client c;
            if (profile_phone_Password.Text == profile_phone_password2.Text && profile_phone_Password.Text.Length > 4)
            {
                c = new Client(profile_firstname.Text, profile_lastname.Text, profile_phone_login.Text, profile_phone_Password.Text, profile_phone.Text, new Address(profile_phone_sity.Text, profile_phone_adres.Text, profile_phone_Dom.Text, profile_phone_Entran.Text));
                Login.Users.Add(c);
                Login.Seria();
            }
            else
                MessageBox.Show("Пароль не співпадають, або коротші ніж 4 символи");
        }
    }
}
