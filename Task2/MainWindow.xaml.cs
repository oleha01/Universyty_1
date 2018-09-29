using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] s = { "Red", "Green", "Blue" };
            arr = new List<Ellipse>();
            cont.Width = 100;
            cont.Height = 100;
            cont.ItemsSource = s;
            cont.Closed += jjhh;

        }
        ContextMenu cont = new ContextMenu();
        Ellipse last;
        List<Ellipse> arr;

        Point p1, p2;
        bool isMove;
        private void jjhh(object sender, RoutedEventArgs e)
        {
            ContextMenu hh = sender as ContextMenu;
            MessageBox.Show(hh.Items.CurrentItem.ToString());

        }


        private void shapesMenu_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((sender as MenuItem).ToString());

        }

        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            p1 = Mouse.GetPosition(canvas);

        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            p2 = Mouse.GetPosition(canvas);
            DrawElipse(p1, p2, false);
            isMove = true;
            last.ContextMenu.IsOpen = true;


        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = Mouse.GetPosition(canvas);
                DrawElipse(p1, p, true);
            }
        }

        private void shapesMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            canvas.Children.RemoveRange(1, canvas.Children.Count - 1);
            shapesMenu.Items.Add("Elipse" + (shapesMenu.Items.Count + 1).ToString());
            shapesMenu.Items.Clear();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            ReadFromFile(of.FileName);
        }
        private void SaveOfFIle(string parth)
        {
            StreamWriter sw = new StreamWriter(parth);
            foreach (var el in arr)
            {
                sw.WriteLine("{0} {1} {2} {3}",
                    el.GetValue(Canvas.LeftProperty),
                    el.GetValue(Canvas.TopProperty),
                    el.ActualHeight,
                    el.ActualWidth);
            }
            sw.Close();
        }
        private void ReadFromFile(string parth)
        {
            StreamReader sr = new StreamReader(parth);
            string s = sr.ReadToEnd();
            var s1 = s.Split('\n');
            for (int i = 0; i < s1.Length; i++)
            {
                var s2 = s1[i].Split(' ');
                Ellipse el = new Ellipse();
                el.SetValue(Canvas.LeftProperty, int.Parse(s2[0]));
                el.SetValue(Canvas.TopProperty, int.Parse(s2[1]));
                el.Height = int.Parse(s2[2]);
                el.Width = int.Parse(s2[3]);
                arr.Add(el);
                canvas.Children.Add(el);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveOfFIle("Text1.txt");
        }



        private void DrawElipse(Point start, Point stop, bool move)
        {
            Ellipse elipse = new Ellipse();

            elipse.ContextMenu = cont;
            last = elipse;
            elipse.Stroke = Brushes.Black;
            elipse.SetValue(Canvas.LeftProperty, start.X);
            elipse.SetValue(Canvas.TopProperty, start.Y);
            if (stop.X - start.X >= 0)
                elipse.Width = stop.X - start.X;
            else
            {
                elipse.Width = start.X - stop.X;
                elipse.SetValue(Canvas.LeftProperty, stop.X);
            }
            if (stop.Y - start.Y >= 0)
                elipse.Height = stop.Y - start.Y;
            else
            {
                elipse.Height = start.Y - stop.Y;
                elipse.SetValue(Canvas.TopProperty, stop.Y);
            }

            if (!move)
            {
                canvas.Children.Add(elipse); arr.Add(elipse);
                shapesMenu.Items.Add("Elipse" + (shapesMenu.Items.Count + 1).ToString());
            }
            else
                if (canvas.Children.Count > 2 && !isMove)
            {
                // if (!ifFirst)
                {
                    canvas.Children.RemoveAt(canvas.Children.Count - 1);
                    canvas.Children.Add(elipse);
                }
                //else
                //{
                //    canvas.Children.Add(elipse);
                //    ifFirst = false;
                //}
            }
            else
            {
                canvas.Children.Add(elipse);
                isMove = false;
            }
        }

    }
}

