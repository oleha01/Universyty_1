//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="LNU">
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
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Dictionary that stores name and value of coloures.
        /// </summary>
       private Dictionary<string, SolidColorBrush> forColor;
       
        XmlSerializer xm = new XmlSerializer(typeof(Ellipse1[]));

        /// <summary>
        /// Stores context menu.
        /// </summary>
        private ContextMenu cont = new ContextMenu();

        /// <summary>
        /// Last ellipse.
        /// </summary>
        private Ellipse last;

        /// <summary>
        /// Current ellipse.
        /// </summary>
        private Ellipse current;

        /// <summary>
        /// List that stores array of ellipses.
        /// </summary>
        private List<Ellipse> arr;
        
         private Ellipse1[] arrSerz;

        /// <summary>
        /// Points of current ellipse.
        /// </summary>
        private Point p1, p2;

        /// <summary>
        /// Boolean value which indicates whether ellipse is in move.
        /// </summary>
        private bool isMove;

        /// <summary>
        /// Boolean value which indicates whether ellipse is movable.
        /// </summary>
        private bool remap;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
           this.InitializeComponent();
            arrSerz = new Ellipse1[25];
            this.remap = false;
            this.forColor = new Dictionary<string, SolidColorBrush>();
            this.forColor.Add("Red", Brushes.Red);
            this.forColor.Add("Green", Brushes.Green);
            this.forColor.Add("Blue", Brushes.Blue);
            MenuItem m1 = new MenuItem();
            MenuItem m2 = new MenuItem();
            MenuItem m3 = new MenuItem();
            m1.Header = "Red";
            m1.Click += (object c, RoutedEventArgs e) => { ColorFilling(m1); };
            m2.Click += (object c, RoutedEventArgs e) => { ColorFilling(m2); };
            m3.Click += (object c, RoutedEventArgs e) => { ColorFilling(m3); };
            m2.Header = "Green";
            m3.Header = "Blue";
            this.arr = new List<Ellipse>();
            this.cont.Width = 100;
            this.cont.Height = 100;
            this.cont.Items.Add(m1);
            this.cont.Items.Add(m2);
            this.cont.Items.Add(m3);
        }

        /// <summary>
        /// Fill the current ellipse with chosen color.
        /// </summary>
        /// <param name="sender">The option of menu with colors names.</param>
        private void ColorFilling(MenuItem sender)
        {
            // MessageBox.Show(sender.Header.ToString());
           var a = this.forColor[sender.Header.ToString()];
            this.last.Fill = a;
            arrSerz[arr.Count - 1].br = sender.Header.ToString();
        }

        /// <summary>
        /// Shows shape menu.
        /// </summary>
        /// <param name="sender">The object that invoke the event that fired <see cref="ShapesMenu_Click(object, MouseButtonEventArgs)"/></param>
        /// <param name="e">Subclassed for more complex controls which is not used in current event.</param>
        private void ShapesMenu_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show((sender as MenuItem).ToString());
        }

        /// <summary>
        /// Sets <see cref="p1"/> position when user press mouse button.
        /// </summary>
        /// <param name="sender">The object that invoke the event that fired <see cref="Canvas_MouseLeftButtonDown(object, MouseButtonEventArgs)"/>.</param>
        /// <param name="e">Subclassed for more complex controls which is not used in current event.</param>
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.p1 = Mouse.GetPosition(this.canvas);
        }

        /// <summary>
        /// Sets <see cref="p2"/> position when user release mouse button and draw new ellipse or makes ellipse unmovable.
        /// </summary>
        /// <param name="sender">The object that invoke the event that fired <see cref="Canvas_MouseLeftButtonUp(object, MouseButtonEventArgs)"/>.</param>
        /// <param name="e">Subclassed for more complex controls which is not used in current event.</param>
        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.remap == false)
            {
                this.p2 = Mouse.GetPosition(this.canvas);
                this.DrawElipse(this.p1, this.p2, false);
                this.isMove = true;
                this.last.ContextMenu.IsOpen = true;
            }
            else
            {
                this.remap = false;
            }
        }

        /// <summary>
        /// Helps to draw the ellipse, or change the position of existing ellipse using cursor.
        /// </summary>
        /// <param name="sender">The object that invoke the event that fired <see cref="Canvas_MouseMove(object, MouseEventArgs)"/>.</param>
        /// <param name="e">Pass the state of the left mouse button(pressed or not).</param>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = Mouse.GetPosition(canvas);
                if (this.remap == false)
                {
                    this.DrawElipse(this.p1, p, true);
                }
                else
                {
                    this.current.SetValue(Canvas.LeftProperty, double.Parse(this.current.GetValue(Canvas.LeftProperty).ToString()) + p.X - this.p1.X);
                    this.current.SetValue(Canvas.TopProperty, double.Parse(this.current.GetValue(Canvas.TopProperty).ToString()) + p.Y - this.p1.Y);
                    this.p1 = p;
                }
            }
        }

        /// <summary>
        /// Clear canvas.
        /// </summary>
        /// <param name="sender">Refers to the "New" option of "File menu" that invoke the event that fired <see cref="MenuItem_Click1(object, RoutedEventArgs)"/></param>
        /// <param name="e">Subclassed for more complex controls which is not used in current event.</param>
        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            canvas.Children.RemoveRange(1, canvas.Children.Count - 1);
            shapesMenu.Items.Add("Elipse" + (shapesMenu.Items.Count + 1).ToString());
            shapesMenu.Items.Clear();
        }

        /// <summary>
        /// Open text file with saved canvas when you click on "Open" option of "File menu".
        /// </summary>
        /// <param name="sender">Refers to the "Open" option of "File menu" that invoke click event that fired <see cref="MenuItem_Click_1(object, RoutedEventArgs)"/>.</param>
        /// <param name="e">Subclassed for more complex controls which is not used in current event.</param>
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            this.ReadFromFile(of.FileName);
        }

        /// <summary>
        /// Function that helps to save current canvas to the text file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        private void SaveFIle(string path)
        {
            using (FileStream fs = new FileStream("Elipse.xml", FileMode.OpenOrCreate))
            {
                xm.Serialize(fs, arrSerz);
            }
        }

        /// <summary>
        /// Function that helps to open text file with canvas.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        private void ReadFromFile(string path)
        {
           arr = new List<Ellipse>();
            shapesMenu.Items.Clear();
            canvas.Children.RemoveRange(1, canvas.Children.Count);
            last = null;
            current = null;
            using (FileStream fs = new FileStream("Elipse.xml", FileMode.OpenOrCreate))
            {
                arrSerz = (Ellipse1[])xm.Deserialize(fs);
            }
            foreach(var el in arrSerz)
            {if(el!=null)
                Draw(el);
            }
        }

        /// <summary>
        /// Save current canvas into text file when you click on "Save" option of File menu.
        /// </summary>
        /// <param name="sender">Refers to the "Save" option of "File menu" that invoke click event that fired <see cref="MenuItem_Click_2(object, RoutedEventArgs)"/>.</param>
        /// <param name="e">Subclassed for more complex controls which is not used in current event.</param>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.SaveFIle("Text1.txt");
        }

        /// <summary>
        /// Allows to moveexisting ellipse.
        /// </summary>
        /// <param name="k">The sequence number of the chosen ellipse.</param>
        private void RemapShapes(int k)
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
        private void DrawElipse(Point start, Point stop, bool move)
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
                elipse1.LeftProperty= stop.X;
            }

            if (stop.Y - start.Y >= 0)
            {
                elipse1.Height = stop.Y - start.Y;
            }
            else
            {
                elipse1.Height = start.Y - stop.Y;
                elipse1.TopProperty=stop.Y;
            }
            Ellipse elipse = elipse1.Draw();
            this.last = elipse;
            elipse.ContextMenu = this.cont;
            if (!move)
            {
                canvas.Children.RemoveAt(canvas.Children.Count - 1);
                canvas.Children.Add(elipse);
                this.arr.Add(elipse);
                this.arrSerz[arr.Count-1]=elipse1;
                MenuItem item1 = new MenuItem();
                int h = shapesMenu.Items.Count;
                item1.Header = "Elipse" + (shapesMenu.Items.Count + 1).ToString();
                item1.Click += (object c, RoutedEventArgs e) => this.RemapShapes(h);
                shapesMenu.Items.Add(item1);
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
    }
}
