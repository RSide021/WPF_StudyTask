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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3lab_C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Point> points = new List<Point>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            points.Add(e.GetPosition(this));

            if(points.Count > 4)
            {
                Polygon p = new Polygon();
                p.Stroke = Brushes.Black;
                p.Fill = Brushes.LightBlue;
                p.StrokeThickness = 1;
                p.HorizontalAlignment = HorizontalAlignment.Left;
                p.VerticalAlignment = VerticalAlignment.Center;
                p.Points = new PointCollection(points);
                canvas.Children.Add(p);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            points.Clear();
            canvas.Children.Clear();
        }
    }
}
