using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Win32;
using Task_2;
using WpfApp1;
using System.Xml.Serialization;
using System;
using System.Windows.Data;

namespace WpfApp1
{
    class Draw
    {
        Canvas canvas;
        Ellipse1 Null;
        MenuItem shapesMenu;
        MainWindow window;
        public string path = "*.*";
        public Draw(Canvas coco, MenuItem f, MainWindow mm)
        {
            canvas = coco;
            shapesMenu = f;
            window = mm;
            Null = new Ellipse1("NULL");
            arrSerz = new Ellipse1[25];
            this.remap = false;
            colorD = new System.Windows.Forms.ColorDialog();
            MenuItem m1 = new MenuItem();
            MenuItem m2 = new MenuItem();
            m1.Header = "Color";
            m2.Header = "Перемістити";
            m1.Click += (object c, RoutedEventArgs e) => { ColorFilling(m1, c); };
            m2.Click += (object c, RoutedEventArgs e) => { this.remap = true; };

            this.arr = new List<Ellipse>();

            this.cont.Items.Add(m1);
            this.cont.Items.Add(m2);
            for (int i = 0; i < 25; i++)
            {
                arrSerz[i] = Null;
            }
            Binding binding = new Binding();

            binding.ElementName = path;
            window.SetBinding(MainWindow.TitleProperty, path);
        }
        /// <summary>
        /// Dictionary that stores name and value of coloures.
        /// </summary>
        public Dictionary<string, SolidColorBrush> forColor;

        XmlSerializer xm = new XmlSerializer(typeof(Ellipse1[]));

        /// <summary>
        /// Stores context menu.
        /// </summary>
        public ContextMenu cont = new ContextMenu();

        /// <summary>
        /// Last ellipse.
        /// </summary>
        public Ellipse last;

        /// <summary>
        /// Current ellipse.
        /// </summary>
        public Ellipse current;

        /// <summary>
        /// List that stores array of ellipses.
        /// </summary>
        public List<Ellipse> arr;

        public Ellipse1[] arrSerz;

        /// <summary>
        /// Points of current ellipse.
        /// </summary>
        public Point p1, p2;

        /// <summary>
        /// Boolean value which indicates whether ellipse is in move.
        /// </summary>
        public bool isMove;

        /// <summary>
        /// Boolean value which indicates whether ellipse is movable.
        /// </summary>
        public bool remap;

        System.Windows.Forms.ColorDialog colorD;

        public void ColorFilling(MenuItem sender, object c)
        {
            // MessageBox.Show(sender.Header.ToString());
            /* var a = this.forColor[sender.Header.ToString()];
              this.last.Fill = a;
              arrSerz[arr.Count - 1].br = sender.Header.ToString();*/

            if (colorD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var el = current;

                var color1 = colorD.Color;
                System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color1.A, color1.R, color1.G, color1.B);
                el.Fill = new SolidColorBrush(newColor);
                int ind = arr.IndexOf(current);
                arrSerz[ind].Red = color1.R;
                arrSerz[ind].Blue = color1.B;
                arrSerz[ind].Green = color1.G;
                arrSerz[ind].A = color1.A;


            }


        }
        /// <summary>
        /// Function that helps to save current canvas to the text file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public void SaveFIle()
        {
            if (path == "*.*")
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == true)
                {
                    path = save.FileName;
                }
            }
            using (StreamWriter fs = new StreamWriter(path))
            {
                xm.Serialize(fs, arrSerz);
            }
        }
        /// <summary>
        /// Function that helps to open text file with canvas.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public void ReadFromFile(string path)
        {
            arr = new List<Ellipse>();
            shapesMenu.Items.Clear();
            canvas.Children.RemoveRange(1, canvas.Children.Count);
            last = null;
            current = null;
            this.path = path;

            using (StreamReader fs = new StreamReader(path))
            {
                arrSerz = (Ellipse1[])xm.Deserialize(fs);
            }
            foreach (var el in arrSerz)
            {
                if (el.Name != Null.Name)
                    DrawOnCanvas(el);
            }
        }

        public void DrawOnCanvas(Ellipse1 el)
        {
            Ellipse elipse = el.Draw();
            arr.Add(elipse);
            MenuItem item1 = new MenuItem();
            elipse.MouseRightButtonDown += Elipse_MouseRightButtonDown;
            int h = arr.Count;
            item1.Header = "Elipse" + (shapesMenu.Items.Count + 1).ToString();
            item1.Click += (object c, RoutedEventArgs e) => this.RemapShapes(h - 1);
            elipse.Name = "E" + h.ToString();
            shapesMenu.Items.Add(item1);
            elipse.MouseRightButtonDown += Elipse_MouseRightButtonDown;
            last = elipse;
            canvas.Children.Add(elipse);
            current = last;
            elipse.ContextMenu = this.cont;
        }

        public void New()
        {
            canvas.Children.RemoveRange(1, canvas.Children.Count - 1);
            shapesMenu.Items.Add("Elipse" + (shapesMenu.Items.Count + 1).ToString());
            arr.Clear();
            for (int i = 0; i < 25; i++)
            {
                arrSerz[i] = Null;
            }
            shapesMenu.Items.Clear();
        }
        public void Read()
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == true)
                ReadFromFile(of.FileName);
        }
        /// <summary>
        /// Allows to moveexisting ellipse.
        /// </summary>
        /// <param name="k">The sequence number of the chosen ellipse.</param>
        public void RemapShapes(int k)
        {
            this.remap = true;
            this.current = this.arr[k];
        }
        /// <summary>
        /// Function that implement drawing of new ellipse on the canvas.
        /// </summary>
        /// <param name="start">Start point.</param>
        /// <param name="stop">Stop point.</param>
        /// <param name="move">Boolean value, that indicates whether ellipse is movable.</param>
        public void DrawElipse(Point start, Point stop, bool move)
        {

            Ellipse1 elipse1 = new Ellipse1();

            elipse1.LeftProperty = start.X;
            elipse1.TopProperty = start.Y;


            if (stop.X - start.X >= 0)
            {
                elipse1.Width = stop.X - start.X;
            }
            else
            {
                elipse1.Width = start.X - stop.X;
                elipse1.LeftProperty = stop.X;
            }

            if (stop.Y - start.Y >= 0)
            {
                elipse1.Height = stop.Y - start.Y;
            }
            else
            {
                elipse1.Height = start.Y - stop.Y;
                elipse1.TopProperty = stop.Y;
            }
            Ellipse elipse = elipse1.Draw();
            this.last = elipse;
            current = last;
            elipse.ContextMenu = this.cont;
            if (!move)
            {
                canvas.Children.RemoveAt(canvas.Children.Count - 1);
                canvas.Children.Add(elipse);
                this.arr.Add(elipse);
                this.arrSerz[arr.Count - 1] = elipse1;
                MenuItem item1 = new MenuItem();
                elipse.MouseRightButtonDown += Elipse_MouseRightButtonDown;
                int h = shapesMenu.Items.Count;
                item1.Header = "Elipse" + (shapesMenu.Items.Count + 1).ToString();
                item1.Click += (object c, RoutedEventArgs e) => this.RemapShapes(h);
                elipse.Name = "E" + h.ToString();
                shapesMenu.Items.Add(item1);
                elipse.Fill = new SolidColorBrush(Colors.White);

            }
            else
                if (canvas.Children.Count > 2 && !this.isMove)
            {
                //// if (!ifFirst)
                {
                    canvas.Children.RemoveAt(canvas.Children.Count - 1);
                    canvas.Children.Add(elipse);
                }
                ////else
                ////{
                ////    canvas.Children.Add(elipse);
                ////    ifFirst = false;
                ////}
            }
            else
            {
                canvas.Children.Add(elipse);
                this.isMove = false;
            }
        }

        public void Elipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            current = sender as Ellipse;
        }
        public void MousePress()
        {
            if (remap == false)
            {
                p2 = Mouse.GetPosition(this.canvas);
                DrawElipse(p1, p2, false);
                isMove = true;

            }
            else
            {
                remap = false;

            }
        }
        public void MousePressed()
        {
            Point p = Mouse.GetPosition(canvas);
            if (remap == false)
            {
                DrawElipse(p1, p, true);
            }
            else
            {
                double left = double.Parse(current.GetValue(Canvas.LeftProperty).ToString()) + p.X - p1.X;
                double top = double.Parse(current.GetValue(Canvas.TopProperty).ToString()) + p.Y - p1.Y;
                current.SetValue(Canvas.LeftProperty, left);
                current.SetValue(Canvas.TopProperty, top);
                arrSerz[arr.IndexOf(current)].LeftProperty = left;
                arrSerz[arr.IndexOf(current)].TopProperty = top;
                p1 = p;
            }
        }
        public void SaveAs()
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == true)
            {
                path = save.FileName;
            }

            using (StreamWriter fs = new StreamWriter(path))
            {
                xm.Serialize(fs, arrSerz);
            }
        }
    }
}
