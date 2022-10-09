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
using System.Windows.Shapes;

namespace lab7
{
    /// <summary>
    /// Логика взаимодействия для Filling.xaml
    /// </summary>
    public partial class Filling : Window
    {
        public Filling()
        {
            InitializeComponent();
            var filling = new List<string>()
            {
                "Моцарелла",
                "Ветчина",
                "Грибы",
                "Маринованные огурцы",
                "Индейка",
                "Оливки",
                "Салями",
                "Помидоры",
                "Ананасы"
            };
            foreach(var el in filling)
            {
                feelList.Items.Add(el);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addedList.Items.Add(feelList.SelectedItem);
            feelList.Items.Remove(feelList.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            feelList.Items.Add(addedList.SelectedItem);
            addedList.Items.Remove(addedList.SelectedItem);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
