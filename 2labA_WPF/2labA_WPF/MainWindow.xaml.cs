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

namespace _2labA_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            combobox.Items.Add("Прямоугольник");
            combobox.Items.Add("Квадрат");
            combobox.Items.Add("Окружность");
            combobox.SelectionChanged += Combobox_SelectionChanged;
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (combobox.SelectedIndex)
            {
                case 0:
                    {
                        alabel.Content = "Сторона a: ";
                        blabel.Content = "Сторона b: ";
                        btextbox.IsEnabled = true;
                        break;
                    }
                case 1:
                    {
                        alabel.Content = "Сторона a: ";
                        blabel.Content = "Сторона b: ";
                        btextbox.IsEnabled = false;
                        break;
                    }
                case 2:
                    {
                        alabel.Content = "pi: ";
                        blabel.Content = "r: ";
                        btextbox.IsEnabled = true;
                        break;
                    }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (combobox.SelectedIndex)
            {
                case 0:
                    {
                        double a = float.Parse(atextbox.Text);
                        double b = float.Parse(btextbox.Text);
                        Rect rect = new Rect(a, b, "прямоугольник");
                        rect.FindSquare();
                        rect.FindPerimeter();
                        rect.Show(namelabel, squarelabel, perimeterlabel);
                        break;
                    }
                case 1:
                    {
                        double a = float.Parse(atextbox.Text);
                        Square square = new Square(a, "квадрат");
                        square.FindSquare();
                        square.FindPerimeter();
                        square.Show(namelabel, squarelabel, perimeterlabel);
                        break;
                    }
                case 2:
                    {
                        double pi = float.Parse(atextbox.Text);
                        double r = float.Parse(btextbox.Text);
                        Circle circle = new Circle(pi, r, "окружность");
                        circle.FindSquare();
                        circle.FindPerimeter();
                        circle.Show(namelabel, squarelabel, perimeterlabel);
                        break;
                    }
            }
        }
    }
    class Shape
    {
        protected double square;
        protected double perimetr;
        protected string name;

        public Shape()
        {
            square = 0;
            perimetr = 0;
            name = "без названия";
        }
        public void Show(Label name, Label square, Label perimeter)
        {
            name.Content = this.name;
            square.Content = this.square;
            perimeter.Content = this.perimetr;
        }
    }

    class Rect : Shape
    {
        public double a;
        public double b;

        public Rect()
        {
            a = 0;
            b = 0;
            name = "прямоугольник";
        }
        public Rect(double a, double b, string name)
        {
            this.a = a;
            this.b = b;
            this.name = name;
        }

        public void FindSquare()
        {
            square = a * b;
        }
        public void FindPerimeter()
        {
            perimetr = 2 * a + 2 * b;
        }
    }
    class Circle : Shape
    {
        public double pi;
        public double r;

        public Circle()
        {
            pi = 0;
            r = 0;
            name = "окружность";
        }
        public Circle(double pi, double r, string name)
        {
            this.pi = pi;
            this.r = r;
            this.name = name;
        }

        public void FindSquare()
        {
            square = pi * Math.Pow(r, 2);
        }
        public void FindPerimeter()
        {
            perimetr = 2 * pi * r;
        }
    }
    class Square : Rect
    {
        public Square() : base()
        {
            a = 0;
            b = a;
        }
        public Square(double a, string name)
        {
            this.a = a;
            b = this.a;
            this.name = name;
        }
    }
}
