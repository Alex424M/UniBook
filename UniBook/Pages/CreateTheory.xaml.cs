using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для CreateTheory.xaml
    /// </summary>
    public partial class CreateTheory : Page
    {
        public CreateTheory()
        {
            InitializeComponent();
        }
        public string direct;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter= "text files(*.docx,*.doc)|*.docx;*.doc|All Files|*.*";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                var sr = ofd.FileName;
                string sourceDir = System.IO.Path.GetDirectoryName(sr);
                string backupDir = @"..\..\Resource";
                try
                {                   
                    string fName = System.IO.Path.GetFileName(sr);

                    try
                    {
                        File.Copy(System.IO.Path.Combine(sourceDir, fName), System.IO.Path.Combine(backupDir, fName));
                        direct = @"C:\Users\NyxSon\Desktop\UniBook\UniBook\Resource" + "\\" + fName;
                    }

                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }

                }
                catch (DirectoryNotFoundException dirNotFound)
                {
                    Console.WriteLine(dirNotFound.Message);
                }

            }
            else MessageBox.Show("Файл для импорта не выбран!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {             
                using (Entities db = new Entities())
                {
                    Material userObject = new Material
                    {
                        Material1 = direct
                    };
                    db.Material.Add(userObject);
                    db.SaveChanges();
                    Theory theory = new Theory
                    {
                        Topic = Topic.Text,
                        IDTeacher = User.ID,
                        IDMaterial = userObject.ID
                    };
                    db.Theory.Add(theory);
                    db.SaveChanges();
                }
                MessageBox.Show("Материал успешно сохранён!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TeacherPage());
        }
    }
}
