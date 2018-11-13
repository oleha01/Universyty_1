using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Runtime;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Data;
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
       public int k = 0;
        List<CarClass> cr;
        List<TextBox> ars = new List<TextBox>();
        List<TextBox> dom = new List<TextBox>();
        List<TextBox> entr = new List<TextBox>();
        public Window1(Client c)
        {
            InitializeComponent();
            tabcontroler.Width = this.Width - 15;
            client = c;
            cr = new List<CarClass>();
            profilePull();
            zvidky_adres.Text = profile_phone_adres.Text;
            zvidky_Dim.Text = profile_phone_Dom.Text;
            zvidky_entra.Text = profile_phone_Entran.Text;
            withoutAdress.Unchecked += withoutAdress_UnChecked;
            table.ItemsSource = Login.orders.Where((i)=> { if (i.ClientName == client.Login) return true; return false; });
            ars.Add(kuda_adres);
            dom.Add(kuda_dim);
            entr.Add(kuda_entra);
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

            Address first = new Address(client.Adress_Client.City, zvidky_adres.Text, zvidky_Dim.Text, zvidky_entra.Text);
            Address sec = null;
            string time = "";
            if (b_check_now.IsChecked == true)
            {
                time = DateTime.Now.ToString();
            }
            List<Address> second = new List<Address>();
            if(withoutAdress.IsChecked==false)
            {
                sec = new Address(client.Adress_Client.City,kuda_adres.Text, kuda_dim.Text, kuda_entra.Text);
            }
            
            Order newor = new Order(client.Login,client.Phone, first,sec,cr,time, Prymitka.Text);
            Login.orders.Add(newor);
            Login.SeriaOrd();
            table.ItemsSource = new List<Order>();
            table.ItemsSource = Login.orders.Where((i) => { if (i.ClientName == client.Login) return true; return false; });
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

        private void b_check_today_Checked(object sender, RoutedEventArgs e)
        {

        }
        int kk = 1;
        private void heightplus()
        {
            
                gridik.RowDefinitions[1].Height = new GridLength(gridik.RowDefinitions[1].Height.Value + 1);  
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Canvas can = new Canvas();
            Thickness t= canvasyk.Margin;
            t.Top = t.Top + kk*30;
   
            kk++;
          //  Int32Animation an = new Int32Animation(300, Duration.Automatic);
            

           // gridik.BeginAnimation(Grid.RowProperty, an);
            gridik.RowDefinitions[1].Height =  new GridLength(gridik.RowDefinitions[1].ActualHeight+ 30);
            can.Margin = t;
            addbuttom.Margin = new Thickness(addbuttom.Margin.Left, addbuttom.Margin.Top+30, addbuttom.Margin.Right, addbuttom.Margin.Bottom) ;
            Label lab = new Label
            {
                Content = "Адрес:",
                Margin = new Thickness(31, 31, 0, 0)

            };
            can.Children.Add(lab);
            Label lab1 = new Label
            {
                Content = "Дім:",
                Margin = new Thickness(310, 31, 0, 0)

            };
            can.Children.Add(lab1);
            Label lab2 = new Label
            {
                Content = "Підїзд:",
                Margin = new Thickness(416, 31, 0, 0)

            };
            can.Children.Add(lab2);
            TextBox t1 = new TextBox
            {
                Text = "",
                Height=18,
                Width=192,
                Margin = new Thickness(95, 31, 0, 0)

            };
            ars.Add(t1);
            can.Children.Add(t1);

            gridik.Children.Add(can);
            can.SetValue(Grid.RowProperty, 1);
            

        }
    }
}