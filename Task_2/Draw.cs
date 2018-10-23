//-----------------------------------------------------------------------
// <copyright file="Draw.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace WpfApp1
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Xml.Serialization;
    using Microsoft.Win32;

    public class Draw
    {
        /// <summary>
        /// Points of current ellipse.
        /// </summary>
        public Point p1, p2;
        public Canvas canvas;
        public Ellipse1 empty;
        public MenuItem shapesMenu;
        public MainWindow window;
        public string path = "*.*";

        public XmlSerializer xm = new XmlSerializer(typeof(Ellipse1[]));

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
        /// Boolean value which indicates whether ellipse is in move.
        /// </summary>
        public bool isMove;

        /// <summary>
        /// Boolean value which indicates whether ellipse is movable.
        /// </summary>
        public bool remap;

        public System.Windows.Forms.ColorDialog colorD;
        public Draw()
        {
            this.p1.X = 0;
            this.p1.Y = 0;
        }
        public Draw(Canvas coco, MenuItem f, MainWindow mm)
        {
            this.canvas = coco;
            this.shapesMenu = f;
            this.window = mm;
            this.empty = new Ellipse1("NULL");
            this.arrSerz = new Ellipse1[25];
            this.remap = false;
            this.colorD = new System.Windows.Forms.ColorDialog();
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
                this.arrSerz[i] = this.empty;
            }

            Binding binding = new Binding();
            binding.ElementName = this.path;
            this.window.SetBinding(MainWindow.TitleProperty, this.path);
        }

        public void SetP1(Point p)
        {
            this.p1 = p;
        }
       
        public void ColorFilling(MenuItem sender, object c)
        {
            // MessageBox.Show(sender.Header.ToString());
            /* var a = this.forColor[sender.Header.ToString()];
              this.last.Fill = a;
              arrSerz[arr.Count - 1].br = sender.Header.ToString();*/

            if (this.colorD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var el = this.current;

                var color1 = this.colorD.Color;
                System.Windows.Media.Color newColor = System.Windows.Media.Color.FromArgb(color1.A, color1.R, color1.G, color1.B);
                el.Fill = new SolidColorBrush(newColor);
                int ind = this.arr.IndexOf(this.current);
                this.arrSerz[ind].Red = color1.R;
                this.arrSerz[ind].Blue = color1.B;
                this.arrSerz[ind].Green = color1.G;
                this.arrSerz[ind].A = color1.A;
            }
        }

        /// <summary>
        /// Function that helps to save current canvas to the text file.
        /// </summary>
        public void SaveFIle()
        {
            if (this.path == "*.*")
            {
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == true)
                {
                    this.path = save.FileName;
                }
            }

            using (StreamWriter fs = new StreamWriter(this.path))
            {
                this.xm.Serialize(fs, this.arrSerz);
            }
        }

        /// <summary>
        /// Function that helps to open text file with canvas.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public void ReadFromFile(string path)
        {
            this.arr = new List<Ellipse>();
            this.shapesMenu.Items.Clear();
            this.canvas.Children.RemoveRange(1, this.canvas.Children.Count);
            this.last = null;
            this.current = null;
            this.path = path;

            using (StreamReader fs = new StreamReader(path))
            {
                this.arrSerz = (Ellipse1[])this.xm.Deserialize(fs);
            }

            foreach (var el in this.arrSerz)
            {
                if (el.Name != this.empty.Name)
                {
                    this.DrawOnCanvas(el);
                }
            }
        }

        public void DrawOnCanvas(Ellipse1 el)
        {
            Ellipse elipse = el.Draw();
            this.arr.Add(elipse);
            MenuItem item1 = new MenuItem();
            elipse.MouseRightButtonDown += this.Elipse_MouseRightButtonDown;
            int h = this.arr.Count;
            item1.Header = "Elipse" + (this.shapesMenu.Items.Count + 1).ToString();
            item1.Click += (object c, RoutedEventArgs e) => this.RemapShapes(h - 1);
            elipse.Name = "E" + h.ToString();
            this.shapesMenu.Items.Add(item1);
            elipse.MouseRightButtonDown += this.Elipse_MouseRightButtonDown;
            this.last = elipse;
            this.canvas.Children.Add(elipse);
            this.current = this.last;
            elipse.ContextMenu = this.cont;
        }

        public void New()
        {
            this.canvas.Children.RemoveRange(1, this.canvas.Children.Count - 1);
            this.shapesMenu.Items.Add("Elipse" + (this.shapesMenu.Items.Count + 1).ToString());
            this.arr.Clear();
            for (int i = 0; i < 25; i++)
            {
                this.arrSerz[i] = this.empty;
            }

            this.shapesMenu.Items.Clear();
        }

        public void Read()
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == true)
            {
                this.ReadFromFile(of.FileName);
            }
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
            this.current = this.last;
            elipse.ContextMenu = this.cont;
            if (!move)
            {
                this.canvas.Children.RemoveAt(this.canvas.Children.Count - 1);
                this.canvas.Children.Add(elipse);
                this.arr.Add(elipse);
                this.arrSerz[this.arr.Count - 1] = elipse1;
                MenuItem item1 = new MenuItem();
                elipse.MouseRightButtonDown += this.Elipse_MouseRightButtonDown;
                int h = this.shapesMenu.Items.Count;
                item1.Header = "Elipse" + (this.shapesMenu.Items.Count + 1).ToString();
                item1.Click += (object c, RoutedEventArgs e) => this.RemapShapes(h);
                elipse.Name = "E" + h.ToString();
                this.shapesMenu.Items.Add(item1);
                elipse.Fill = new SolidColorBrush(Colors.White);
            }
            else
                if (this.canvas.Children.Count > 2 && !this.isMove)
            {
                //// if (!ifFirst)
                {
                    this.canvas.Children.RemoveAt(this.canvas.Children.Count - 1);
                    this.canvas.Children.Add(elipse);
                }
                ////else
                ////{
                ////    canvas.Children.Add(elipse);
                ////    ifFirst = false;
                ////}
            }
            else
            {
                this.canvas.Children.Add(elipse);
                this.isMove = false;
            }
        }

        public void Elipse_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.current = sender as Ellipse;
        }

        public void MousePress()
        {
            if (this.remap == false)
            {
                this.p2 = Mouse.GetPosition(this.canvas);
                this.DrawElipse(this.p1, this.p2, false);
                this.isMove = true;
            }
            else
            {
                this.remap = false;
            }
        }

        public void MousePressed()
        {
            Point p = Mouse.GetPosition(this.canvas);
            if (this.remap == false)
            {
                this.DrawElipse(this.p1, p, true);
            }
            else
            {
                double left = double.Parse(this.current.GetValue(Canvas.LeftProperty).ToString()) + p.X - this.p1.X;
                double top = double.Parse(this.current.GetValue(Canvas.TopProperty).ToString()) + p.Y - this.p1.Y;
                this.current.SetValue(Canvas.LeftProperty, left);
                this.current.SetValue(Canvas.TopProperty, top);
                this.arrSerz[this.arr.IndexOf(this.current)].LeftProperty = left;
                this.arrSerz[this.arr.IndexOf(this.current)].TopProperty = top;
                this.p1 = p;
            }
        }

        public void SaveAs()
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == true)
            {
                this.path = save.FileName;
            }

            using (StreamWriter fs = new StreamWriter(this.path))
            {
                this.xm.Serialize(fs, this.arrSerz);
            }
        }
    }
}
