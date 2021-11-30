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

namespace UniBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для PassingTest.xaml
    /// </summary>
    public partial class PassingTest : Page
    {
        public PassingTest()
        {
            InitializeComponent();
            cmb1.ItemsSource = Entities.GetContext().Theory.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = cmb1.Text;
            string sqlExpression = $"SELECT ID FROM Theory WHERE TOPIC='{name}'";
            using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-E0VOF7A;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = sqlExpression;
                command.Connection = connection;
                name = command.ExecuteScalar().ToString();
            }
            NavigationService?.Navigate(new PassingTest2(int.Parse(name)));
        }
    }
}
