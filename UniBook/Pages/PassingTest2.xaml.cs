using System;
using System.Collections.Generic;
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
        int k = 0;
        int IdTest1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            questionlbl.Content = questionlist[k];
            k++;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //string name;
            //string sqlExpression = $"SELECT Question FROM Questions WHERE IDTesting='{IdTest1}'";
            //using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-E0VOF7A;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand();
            //    command.CommandText = sqlExpression;
            //    command.Connection = connection;
            //    questionlist =command.;
            //}
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
