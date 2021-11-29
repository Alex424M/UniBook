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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            CmbGroup.ItemsSource = Entities.GetContext().Group.ToList();
        }

        private void CheckTeacher_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckTeacher.IsChecked == true)
            {
                CmbGroup.Visibility = Visibility.Hidden;
                LblGroup.Visibility = Visibility.Hidden;
            }
        }

        private void CheckTeacher_Unchecked(object sender, RoutedEventArgs e)
        {
            if (CheckTeacher.IsChecked == false)
            {
                CmbGroup.Visibility = Visibility.Visible;
                LblGroup.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Passwords.Password) || string.IsNullOrEmpty(RepPass.Password))
            {
                if (CheckTeacher.IsChecked == false && CmbGroup.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все поля");
                }
            }

            else if (Passwords.Password.Length >= 6)
            {
                bool en = true; // английская раскладка

                for (int i = 0; i < Passwords.Password.Length; i++) // перебираем символы
                {
                    if (Passwords.Password[i] >= 'А' && Passwords.Password[i] <= 'Я') en = false; // если русская раскладка
                }

                if (!en)
                    MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                else if (Passwords.Password == RepPass.Password) // проверка на совпадение паролей
                {
                    MessageBox.Show("Пользователь зарегистрирован");
                    if (CheckTeacher.IsChecked == true)
                    {
                        using (Entities db = new Entities())
                        {
                            Teacher userObject = new Teacher
                            {
                                FIO = Login.Text,
                                Password = Passwords.Password
                            };
                            db.Teacher.Add(userObject);
                            db.SaveChanges();
                        }
                    }
                    else if (CheckTeacher.IsChecked == false)
                    {
                        using (Entities db = new Entities())
                        {
                            Student userObject = new Student
                            {
                                FIO = Login.Text,
                                Password = Passwords.Password,
                                IDGroup = CmbGroup.SelectedIndex + 1
                            };
                            db.Student.Add(userObject);
                            db.SaveChanges();
                        }
                    }
                    NavigationService?.GoBack();
                }
                else MessageBox.Show("Пароли не совподают");
            }
            else MessageBox.Show("пароль слишком короткий, минимум 6 символов");
        }
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Passwords.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }
        private void OnPasswordChanged1(object sender, RoutedEventArgs e)
        {
            if (RepPass.Password.Length > 0)
            {
                Watermark1.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark1.Visibility = Visibility.Visible;
            }
        }
        private void OnItemChanged(object sender, RoutedEventArgs e)
        {
            if (CmbGroup.SelectedIndex > -1)
            {
                Watermark2.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark2.Visibility = Visibility.Visible;
            }
        }
    }
}
