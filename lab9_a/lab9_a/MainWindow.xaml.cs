using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace lab9_a
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

    }
    public class NameMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string day = values[0].ToString();
            string month = values[1].ToString();
            string year = values[2].ToString();
            if(!string.IsNullOrEmpty(day) && !string.IsNullOrEmpty(month) && !string.IsNullOrEmpty(year))
            {
                if(DateTime.TryParse($"{year}-{month}-{day}", out DateTime dateTime))
                {
                    return dateTime;
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return new object[] { date.Day.ToString(), date.Month.ToString(), date.Year.ToString() };
        }
    }
}
