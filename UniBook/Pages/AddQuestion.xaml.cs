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
    /// Логика взаимодействия для AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Page
    {
        public AddQuestion()
        {
            InitializeComponent();
            //DataContext = questions;
            //if (selectedPost != null)
            //    _post = selectedPost;
            cmb1.ItemsSource = Entities.GetContext().Theory.ToList();
        }
        //private Questions questions = new Questions();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (cmb1.SelectedIndex == -1)
                errors.AppendLine("Выберите тему!");
            if (string.IsNullOrWhiteSpace(txtQustion.Text))
                errors.AppendLine("Укажите вопрос!");
            if (string.IsNullOrWhiteSpace(txtAnswer1.Text))
                errors.AppendLine("Укажите 1 ответ!");
            if (string.IsNullOrWhiteSpace(txtAnswer2.Text))
                errors.AppendLine("Укажите 2 ответ!");
            if (string.IsNullOrWhiteSpace(txtAnswer3.Text))
                errors.AppendLine("Укажите 3 ответ!");
            if (string.IsNullOrWhiteSpace(txtAnswer4.Text))
                errors.AppendLine("Укажите 4 ответ!");
            if (string.IsNullOrWhiteSpace(txtTrueAnswer.Text))
                errors.AppendLine("Укажите правильный ответ!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                using (Entities db = new Entities())
                {
                    Questions questions = new Questions
                    {
                        Question = txtQustion.Text,
                        Option1 = txtAnswer1.Text,
                        Option2 = txtAnswer2.Text,
                        Option3 = txtAnswer3.Text,
                        Option4 = txtAnswer4.Text,
                        Answer = txtTrueAnswer.Text,
                        IDTheory = cmb1.SelectedIndex + 1
                    };
                    db.Questions.Add(questions);
                    db.SaveChanges();
                }
                MessageBox.Show("Вопрос успешно сохранён!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //if (questions.ID == 0)
            //    Entities.GetContext().Questions.Add(questions);

            //    Entities.GetContext().SaveChanges();
            //    MessageBox.Show("Данные успешно сохранены!");

        }


        private void OnItemChanged(object sender, RoutedEventArgs e)
        {
            if (cmb1.SelectedIndex > -1)
            {
                Watermark2.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark2.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateTesting());
        }
    }
}
