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
    /// Логика взаимодействия для PassingTest2.xaml
    /// </summary>
    public partial class PassingTest2 : Page
    {
        public PassingTest2(int IdTest)
        {
            InitializeComponent();
            IdTest1 = IdTest;
        }
        List<string> questionlist = new List<string>();
        int IdTest1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"SELECT TOP 5 Question, Option1, Option2, Option3, Option4, Answer FROM Questions WHERE IDTheory={IdTest1} ORDER BY IDTheory DESC";
            using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-E0VOF7A;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
            {
                connection.Open();
                SqlCommand createCommand = new SqlCommand(sqlExpression, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Questions"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                dgQuest.ItemsSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
