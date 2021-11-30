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
            if (checkbox1.IsChecked == false)
            {
                if (string.IsNullOrWhiteSpace(txtAnswer2.Text))
                    errors.AppendLine("Укажите 2 ответ!");
                if (string.IsNullOrWhiteSpace(txtAnswer3.Text))
                    errors.AppendLine("Укажите 3 ответ!");
                if (string.IsNullOrWhiteSpace(txtAnswer4.Text))
                    errors.AppendLine("Укажите 4 ответ!");
            }
            if (string.IsNullOrWhiteSpace(txtTrueAnswer.Text))
                errors.AppendLine("Укажите правильный ответ!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (checkbox1.IsChecked == false)
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
                        IDTesting = 1,
                        IDTheory = cmb1.SelectedIndex + 1
                    };
                    db.Questions.Add(questions);
                    db.SaveChanges();
                }
            }
            else
            {
                using (Entities db = new Entities())
                {
                    Questions questions = new Questions
                    {
                        Question = txtQustion.Text,
                        Option1 = txtAnswer1.Text,
                        Answer = txtTrueAnswer.Text,
                        IDTesting = 1,
                        IDTheory = cmb1.SelectedIndex + 1
                    };
                    db.Questions.Add(questions);
                    db.SaveChanges();
                }
            }
            //if (questions.ID == 0)
            //    Entities.GetContext().Questions.Add(questions);

            //    Entities.GetContext().SaveChanges();
            //    MessageBox.Show("Данные успешно сохранены!");

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            txtAnswer1.IsEnabled = false;
            txtAnswer2.IsEnabled = false;
            txtAnswer3.IsEnabled = false;
            txtAnswer4.IsEnabled = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAnswer1.IsEnabled = true;
            txtAnswer2.IsEnabled = true;
            txtAnswer3.IsEnabled = true;
            txtAnswer4.IsEnabled = true;
        }
    }
}
