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

namespace lab7
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
            Filling filling = new Filling();
            if(filling.ShowDialog() == true)
            {
                chooseFill.Items.Clear();
                chooseFill.ItemsSource = filling.addedList.Items;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if((bool)radio1.IsChecked || (bool)radio2.IsChecked || (bool)radio3.IsChecked)
            {
                if(chooseFill.Items.Count > 0)
                {
                    var cost = (bool)radio1.IsChecked ? 450 : (bool)radio2.IsChecked ? 340 : 280;
                    foreach(var el in chooseFill.Items)
                    {
                        cost += 20;
                    }
                    costOrder.Content = cost;
                    costPost.Content = "100";
                    costAll.Content = cost + 100;
                }
            }
        }
    }
}
