using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Logic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlatformTask_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ////Client cl = new Client("Roma", "Koltun", "Rom32", "222", "+380989233113", new Address("Lviv", "Horodozka", "5", "0"));
            Client cl = null;
            cl = Login.Users.Find(cl1 => { if (cl1.Login == login.Text) return true; return false; });
            if (cl != null && cl.Password == password.Text)
            {
                Window1 ww = new Window1(cl);
                this.Visibility = Visibility.Hidden;
                ww.ShowDialog();
                this.Visibility = Visibility.Visible;
            }
            else
                MessageBox.Show("Не вірний логін, або пароль");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Reg f = new Reg();
            this.Visibility = Visibility.Hidden;
            f.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}