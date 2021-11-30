﻿using System;
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
    /// Логика взаимодействия для CreateTesting.xaml
    /// </summary>
    public partial class CreateTesting : Page
    {
        public CreateTesting()
        {
            InitializeComponent();
            dgQuestion.ItemsSource = Entities.GetContext().Questions.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddQuestion());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //    if (Visibility == Visibility.Visible)
            //    {
            //        Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            //        dgQuestion.ItemsSource = Entities.GetContext().Questions.ToList();
            //    }
        }
    }
}