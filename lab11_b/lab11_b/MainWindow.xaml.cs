using Microsoft.Win32;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace lab11_b
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Excel.Range Rng;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSht;

        DataTable dataTable = new DataTable("table");
        Excel.Application xlApp;
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.CellEditEnding += DataGrid_CellEditEnding;
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int row = e.Row.GetIndex() + 1;
            int col = e.Column.DisplayIndex + 1;
            (xlSht.Cells[row, col] as Excel.Range).Value = dataTable.Rows[row-1][col-1];
            xlWB.Close();
            xlApp.Quit();
            dataTable.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }
            string xlFileName = openFileDialog.FileName;

            xlApp = new Excel.Application();
            xlWB = xlApp.Workbooks.Open(xlFileName);          
            xlSht = xlWB.Worksheets["Лист1"]; 
            Rng = xlSht.UsedRange;
            int rowCount = Rng.Rows.Count;
            int colCount = Rng.Columns.Count;
            for (int j = 1; j <= colCount; j++)
            {
                dataTable.Columns.Add($"col{j}");
                dataGrid.Columns.Add(
                          new DataGridTextColumn
                          {
                              Header = $"col{j}",
                              Binding = new Binding(string.Format("[{0}]", $"col{j}"))
                          });
            }

            for (int i = 1; i <= rowCount; i++)
            {
                dataTable.Rows.Add();
                for (int j = 1; j <= colCount; j++)
                {
                    dataTable.Rows[i - 1][j - 1] = Rng.Cells[i, j].value;
                }
            }
            dataGrid.DataContext = dataTable;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
