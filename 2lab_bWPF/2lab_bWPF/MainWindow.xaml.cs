using System;
using System.Collections.Generic;
using System.IO;
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

namespace _2lab_bWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Deck deck = new Deck();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] fullfilesPath = Directory.GetFiles(@"C:\Users\admin\Desktop\Resources\");
            for (int i = 0; i < fullfilesPath.Length; i++)
            {
                var name = System.IO.Path.GetFileName(fullfilesPath[i]);
                name = name.Substring(0, name.IndexOf("."));
                var index = name.IndexOf("_");
                var suit = name.Substring(0, index);
                var rank = name.Substring(index + 1);
                deck.SetCard(i, rank, suit);
            }
            int row = 0;
            int clmn = 0;
            for (int i = 0; i < 36; i++)
            {
                string path = $@"C:\Users\admin\Desktop\Resources\{deck.GetCard(i).ToString()}.jpg";
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(path));
                grid.Children.Add(image);
                if (i != 0)
                {
                    if (i % 6 == 0)
                    {
                        row++;
                        clmn = 0;
                    }
                }
                Grid.SetRow(image, row);
                Grid.SetColumn(image, clmn);
                clmn++;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            deck.Shuffle();
            int row = 0;
            int clmn = 0;
            for (int i = 0; i < 36; i++)
            {
                string path = $@"C:\Users\admin\Desktop\Resources\{deck.GetCard(i).ToString()}.jpg";
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(path));
                grid.Children.Add(image);
                if (i != 0)
                {
                    if (i % 6 == 0)
                    {
                        row++;
                        clmn = 0;
                    }
                }
                Grid.SetRow(image, row);
                Grid.SetColumn(image, clmn);
                clmn++;
            }
        }
    }
    class Card
    {
        private string suit;
        private string rank;
        private Card() { }
        public Card(string suit, string rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
        public override string ToString()
        {
            return $"{suit}_{rank}";
        }
    }
    class Deck
    {
        private Card[] cards;
        public Deck()
        {
            this.cards = new Card[36];
        }
        public void SetCard(int i, string rank, string suit)
        {
            if (i >= 0 && i < 36)
            {
                this.cards[i] = new Card(suit, rank);
            }
        }
        public Card GetCard(int i)
        {
            if (i >= 0 && i < 36)
            {
                return cards[i];
            }
            return null;
        }
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = cards.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }
    }
}
