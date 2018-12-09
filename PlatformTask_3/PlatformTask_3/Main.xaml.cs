//-----------------------------------------------------------------------
// <copyright file="Main.xaml.cs" company="LNU">
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
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Logic;
    using System.Data.Entity;

    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// Information about the client.
        /// </summary>
        private Client client;

        /// <summary>
        /// List of car`s classes.
        /// </summary>
        private List<CarClass> cr;

        /// <summary>
        /// List of addresses.
        /// </summary>
        private List<TextBox> ars = new List<TextBox>();

        /// <summary>
        /// List of buildings.
        /// </summary>
        private List<TextBox> dom = new List<TextBox>();

        /// <summary>
        /// List of enterences.
        /// </summary>
        private List<TextBox> entr = new List<TextBox>();

        /// <summary>
        /// Thickness of the line.
        /// </summary>
        private int kk = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1" /> class.
        /// </summary>
        /// <param name="c">Information about the client.</param>
        public Window1(Client c)
        {
            this.InitializeComponent();
            tabcontroler.Width = this.Width - 15;
            this.client = c;
            this.cr = new List<CarClass>();
            this.ProfilePull();
            this.zvidky_adres.Text = profile_phone_adres.Text;
            this.zvidky_Dim.Text = profile_phone_Dom.Text;
            this.zvidky_entra.Text = profile_phone_Entran.Text;
            this.withoutAdress.Unchecked += this.WithoutAdress_UnChecked;
            List<Order> tt = new List<Order>();
            table.ItemsSource =  Login.unit.Orders.GetAll().Where(o => o.ClientName == client.Login).ToList() ;
            
            this.ars.Add(this.kuda_adres);
            this.dom.Add(this.kuda_dim);
            this.entr.Add(this.kuda_entra);
        }

        /// <summary>
        /// Save inputed information.
        /// </summary>
        private void ProfilePull()
        {
            profile_firstname.Text = this.client.Name;
            profile_lastname.Text = this.client.LastName;
            profile_phone.Text = this.client.Phone;
            Address adr111 = client.Adress_Client;
            
            profile_phone_Dom.Text = adr111.House;
            profile_phone_adres.Text = adr111.Street;
            profile_phone_Entran.Text = adr111.Entrance;
        }

        /// <summary>
        /// Save information about the order.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Address first = new Address(this.client.Adress_Client.City, zvidky_adres.Text, zvidky_Dim.Text, zvidky_entra.Text);
            Address sec = null;
            string time = string.Empty;
            if (b_check_now.IsChecked == true)
            {
                time = DateTime.Now.ToString();
            }

            List<Address> second = new List<Address>();
            if (withoutAdress.IsChecked == false)
            {
                sec = new Address(this.client.Adress_Client.City, kuda_adres.Text, kuda_dim.Text, kuda_entra.Text);
            }

            Order newor = new Order(this.client.Login, this.client.Phone, first, sec, this.cr, time, Prymitka.Text);
            Login.unit.Orders.Create(newor);
            Login.unit.Save();
            table.ItemsSource = new List<Order>();
            table.ItemsSource = Login.unit.Orders.GetAll().Where(o => o.ClientName == client.Login).ToList();
        }

        /// <summary>
        /// Make textbox invisible.
        /// </summary>
        /// <param name="t">Textbox that should be invisible.</param>
        private void Invisible(TextBox t)
        {
            t.IsReadOnly = true;
            t.Foreground = Brushes.LightGray;
        }

        /// <summary>
        /// Make textbox Visible.
        /// </summary>
        /// <param name="t">Textbox that should be Visible.</param>
        private void Visible(TextBox t)
        {
            t.IsReadOnly = false;
            t.Foreground = Brushes.Black;
        }

        /// <summary>
        /// Make part of the form invisible if checkbox is checked.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void VithoutAdress_Checked(object sender, RoutedEventArgs e)
        {
            this.Invisible(this.kuda_adres);
            this.Invisible(this.kuda_dim);
            this.Invisible(this.kuda_entra);
        }

        /// <summary>
        /// Make part of the form Visible if checkbox is unchecked.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void WithoutAdress_UnChecked(object sender, RoutedEventArgs e)
        {
            this.Visible(this.kuda_adres);
            this.Visible(this.kuda_dim);
            this.Visible(this.kuda_entra);
        }

        /// <summary>
        /// Changes height.
        /// </summary>
        private void HeightPlus()
        {
            gridik.RowDefinitions[1].Height = new GridLength(gridik.RowDefinitions[1].Height.Value + 1);
        }

        /// <summary>
        /// Changes window appearance.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Canvas can = new Canvas();
            Thickness t = canvasyk.Margin;
            t.Top += this.kk * 30;

            this.kk++;
            //// Int32Animation an = new Int32Animation(300, Duration.Automatic);
            //// gridik.BeginAnimation(Grid.RowProperty, an);
            gridik.RowDefinitions[1].Height = new GridLength(gridik.RowDefinitions[1].ActualHeight + 30);
            can.Margin = t;
            addbuttom.Margin = new Thickness(addbuttom.Margin.Left, addbuttom.Margin.Top + 30, addbuttom.Margin.Right, addbuttom.Margin.Bottom);
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
                Text = string.Empty,
                Height = 18,
                Width = 192,
                Margin = new Thickness(95, 31, 0, 0)
            };
            this.ars.Add(t1);
            can.Children.Add(t1);

            gridik.Children.Add(can);
            can.SetValue(Grid.RowProperty, 1);
        }

        /// <summary>
        /// Changes window appearance.
        /// </summary>
        /// <param name="sender">The object that invoked the event that fired the event handler.</param>
        /// <param name="e">Subclassed for more complex controls.</param>
        private void AddButtom_Click(object sender, RoutedEventArgs e)
        {
            this.Button_Click_1(sender, e);
        }
    }
}