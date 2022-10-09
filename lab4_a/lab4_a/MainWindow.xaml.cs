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

namespace lab4_a
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isBold = false;
        bool isItalic = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bold_Click(object sender, RoutedEventArgs e)
        {
            if (isBold)
            {
                richTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Normal);
            }
            else
            {
                richTextBox.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            }
            isBold = !isBold;
        }

        private void italic_Click(object sender, RoutedEventArgs e)
        {
            if (isItalic)
            {
                richTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Normal);
            }
            else
            {
                richTextBox.Selection.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
            }
            isItalic = !isItalic;
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(richTextBox != null)
            {
                richTextBox.Selection.ApplyPropertyValue(FontSizeProperty, e.NewValue);
            }
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (richTextBox != null)
            {
                richTextBox.Selection.ApplyPropertyValue(FontFamilyProperty, combobox.SelectedItem);
            }
        }
    }
}
