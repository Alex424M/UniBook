using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Xps.Packaging;

namespace UniBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowTheory.xaml
    /// </summary>
    public partial class ShowTheory : System.Windows.Controls.Page
    {
        public ShowTheory()
        {
            InitializeComponent();
            DataGrid.ItemsSource = Entities.GetContext().Theory.ToList();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            //string sqlExpression = $"SELECT ID FROM Theory WHERE TOPIC='{name}'";
            //using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-PINVO2L\SQLEXPRESS;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = sqlExpression;
            //    command.Connection = connection;
            //    name = command.ExecuteScalar().ToString();
            //}
            //NavigationService?.Navigate(new ShowMaterial());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedColumn = DataGrid.CurrentCell.Column.DisplayIndex;
            var selectedCell = DataGrid.SelectedCells[selectedColumn];
            var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
            if (cellContent is TextBlock)
            {
                string name = (cellContent as TextBlock).Text;
                string sqlExpression = $"SELECT IDMaterial FROM Theory WHERE TOPIC='{name}'";
                using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-PINVO2L\SQLEXPRESS;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = sqlExpression;
                    command.Connection = connection;
                    name = command.ExecuteScalar().ToString();
                }
                NavigationService?.Navigate(new ShowMaterial(int.Parse(name)));

            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StudentPage());
        }
    }
}
