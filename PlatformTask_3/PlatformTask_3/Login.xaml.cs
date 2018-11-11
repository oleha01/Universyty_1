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
        Login log;
        public MainWindow()
        {
            InitializeComponent();
            Login log = new Login();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               if( log.users[login.Text]==password.Text)
                {

                }
            }
            catch
            {
                MessageBox.Show("Не вірний логін, або пароль");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
