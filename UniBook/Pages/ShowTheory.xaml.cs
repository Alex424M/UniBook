using Microsoft.Office.Interop.Word;
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
            NavigationService?.Navigate(new ShowMaterial());
        }
    }
}
