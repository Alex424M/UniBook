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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public static string name;
        public AuthPage()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            using (var uniBook = new Entities())
            {
                var student = uniBook.Student
                    .AsNoTracking()
                    .FirstOrDefault(u => u.FIO == Login.Text && u.Password == Password.Password);
                if (student == null)
                {
                    var teacher = uniBook.Teacher
                    .AsNoTracking()
                    .FirstOrDefault(u => u.FIO == Login.Text && u.Password == Password.Password);
                    if (teacher == null)
                    {
                        MessageBox.Show("Пользователь не найден!");
                        return;
                    }
                    else
                    {
                        setUser(teacher.FIO, teacher.ID);
                        NavigationService?.Navigate(new TeacherPage());
                    }
                }
                else
                {
                    setUser(student.FIO, student.ID, student.IDGroup);
                    NavigationService?.Navigate(new StudentPage());
                }
            }
        }
        private void setUser(string name, int id)
        {
            User.ID = id;
            User.Name = name;
        }
        private void setUser(string name, int id, int group)
        {
            User.ID = id;
            User.Name = name;
            User.IDGroup = group;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Password.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MainPage());
        }
    }
}