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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logic;

namespace PlatformTask_3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Client client;
        public Window1(Client c)
        {
            InitializeComponent();
            tabcontroler.Width = this.Width - 15;
            client = c;
            profilePull();
            zvidky_adres.Text = profile_phone_adres.Text;
            zvidky_Dim.Text = profile_phone_Dom.Text;
            zvidky_entra.Text = profile_phone_Entran.Text;
            withoutAdress.Unchecked += withoutAdress_UnChecked;
        }
        private void profilePull()
        {
            profile_firstname.Text = client.Name;
            profile_lastname.Text = client.LastName;
            profile_phone.Text = client.Phone;
            profile_phone_Dom.Text = client.Adress_Client.House;
            profile_phone_adres.Text = client.Adress_Client.Street;
            profile_phone_Entran.Text = client.Adress_Client.Entrance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(withoutAdress.IsChecked==false)
            {

            }
        }
        private void unvisible(TextBox t)
        {
            t.IsReadOnly = true;
            t.Foreground = Brushes.LightGray;
        }
        private void visible(TextBox t)
        {
            t.IsReadOnly = false;
            t.Foreground = Brushes.Black;
        }
        private void withoutAdress_Checked(object sender, RoutedEventArgs e)
        {
            unvisible(kuda_adres);
            unvisible(kuda_dim);
            unvisible(kuda_entra);
        }
        private void withoutAdress_UnChecked(object sender, RoutedEventArgs e)
        {
            visible(kuda_adres);
            visible(kuda_dim);
            visible(kuda_entra);
        }
    }
}
