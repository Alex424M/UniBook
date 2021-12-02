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

namespace UniBook.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowRating.xaml
    /// </summary>
    public partial class ShowRating : Page
    {
        public ShowRating()
        {
            InitializeComponent();
            dgQuestion.ItemsSource= Entities.GetContext().Testing.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
