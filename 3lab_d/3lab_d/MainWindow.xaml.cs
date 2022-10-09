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

namespace _3lab_d
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
            VisualBrush myBrush = new VisualBrush();
            myBrush.Visual = btn;
            rect.Fill = myBrush;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush(Color.FromRgb(209, 227, 250), Color.FromRgb(170, 199, 238), new Point(0.5, 0), new Point(0.5, 1));
            rect.Fill = gradientBrush;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RadialGradientBrush fiveColorRGB = new RadialGradientBrush();
            fiveColorRGB.GradientOrigin = new Point(0.5, 0.5);
            fiveColorRGB.Center = new Point(0.5, 0.5);

            GradientStop blueGS = new GradientStop();
            blueGS.Color = Colors.Blue;
            blueGS.Offset = 0.0;
            fiveColorRGB.GradientStops.Add(blueGS);

            GradientStop orangeGS = new GradientStop();
            orangeGS.Color = Colors.Orange;
            orangeGS.Offset = 0.25;
            fiveColorRGB.GradientStops.Add(orangeGS);

            GradientStop yellowGS = new GradientStop();
            yellowGS.Color = Colors.Yellow;
            yellowGS.Offset = 0.50;
            fiveColorRGB.GradientStops.Add(yellowGS);

            GradientStop greenGS = new GradientStop();
            greenGS.Color = Colors.Green;
            greenGS.Offset = 0.75;
            fiveColorRGB.GradientStops.Add(greenGS);

            GradientStop redGS = new GradientStop();
            redGS.Color = Colors.Red;
            redGS.Offset = 1.0;
            fiveColorRGB.GradientStops.Add(redGS);
            rect.Fill = fiveColorRGB;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            rect.Fill = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\admin\Desktop\qq.jpg", UriKind.Relative)));
        }
    }
}
