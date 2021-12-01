﻿using System;
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
        List<string> opt1 = new List<string>();
        List<string> opt2 = new List<string>();
        List<string> opt3 = new List<string>();
        List<string> opt4 = new List<string>();
        List<string> ans = new List<string>();
        int IdTest1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int estimation = 0;
            if (ans[0] != q11.Content && q11.IsChecked == false)
            {
                if (ans[0] != q12.Content && q12.IsChecked == false)
                {
                    if (ans[0] != q13.Content && q13.IsChecked == false)
                    {
                        if (ans[0] != q14.Content && q14.IsChecked == false)
                        {
                            MessageBox.Show("Успех","Ошибка");
                        }
                        else
                        {
                            estimation++;
                        }
                    }
                    else
                    {
                        estimation++;
                    }
                }
                else
                {
                    estimation++;
                }
            }
            else
            {
                estimation++;
            }
            if (ans[1] != q21.Content && q21.IsChecked == false)
            {
                if (ans[1] != q22.Content && q22.IsChecked == false)
                {
                    if (ans[1] != q23.Content && q23.IsChecked == false)
                    {
                        if (ans[1] != q24.Content && q24.IsChecked == false)
                        {
                            MessageBox.Show("Успех", "Ошибка");
                        }
                        else
                        {
                            estimation++;
                        }
                    }
                    else
                    {
                        estimation++;
                    }
                }
                else
                {
                    estimation++;
                }
            }
            else
            {
                estimation++;
            }
            if (ans[2] != q31.Content && q31.IsChecked == false)
            {
                if (ans[2] != q32.Content && q32.IsChecked == false)
                {
                    if (ans[2] != q33.Content && q33.IsChecked == false)
                    {
                        if (ans[2] != q34.Content && q34.IsChecked == false)
                        {
                            MessageBox.Show("Успех", "Ошибка");
                        }
                        else
                        {
                            estimation++;
                        }
                    }
                    else
                    {
                        estimation++;
                    }
                }
                else
                {
                    estimation++;
                }
            }
            else
            {
                estimation++;
            }
            if (ans[3] != q41.Content && q41.IsChecked == false)
            {
                if (ans[3] != q42.Content && q42.IsChecked == false)
                {
                    if (ans[3] != q43.Content && q43.IsChecked == false)
                    {
                        if (ans[3] != q44.Content && q44.IsChecked == false)
                        {
                            MessageBox.Show("Успех", "Ошибка");
                        }
                        else
                        {
                            estimation++;
                        }
                    }
                    else
                    {
                        estimation++;
                    }
                }
                else
                {
                    estimation++;
                }
            }
            else
            {
                estimation++;
            }
            if (ans[4] != q51.Content && q51.IsChecked == false)
            {
                if (ans[4] != q52.Content && q52.IsChecked == false)
                {
                    if (ans[4] != q53.Content && q53.IsChecked == false)
                    {
                        if (ans[4] != q54.Content && q54.IsChecked == false)
                        {
                            MessageBox.Show("Успех", "Ошибка");
                        }
                        else
                        {
                            estimation++;
                        }
                    }
                    else
                    {
                        estimation++;
                    }
                }
                else
                {
                    estimation++;
                }
            }
            else
            {
                estimation++;
            }
            est.Content = $"Ваша оценка: {estimation}";
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string sqlExpression = $"SELECT TOP 5 Question, Option1, Option2, Option3, Option4, Answer FROM Questions WHERE IDTheory={IdTest1} ORDER BY IDTheory ASC";
            using (SqlConnection connection = new SqlConnection(@"data source=DESKTOP-E0VOF7A;initial catalog=UniBook;integrated security=True;MultipleActiveResultSets=True;"))
            {
                connection.Open();
                SqlCommand createCommand = new SqlCommand(sqlExpression, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Questions"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);
                dgQuest1.DataSource = dt.DefaultView; // Сам вывод 
                connection.Close();
            }
            for (int i = 0; i < 5; i++)
            {
                questionlist.Add(dgQuest1[0, i].Value.ToString());
                opt1.Add(dgQuest1[1, i].Value.ToString());
                opt2.Add(dgQuest1[2, i].Value.ToString());
                opt3.Add(dgQuest1[3, i].Value.ToString());
                opt4.Add(dgQuest1[4, i].Value.ToString());
                ans.Add(dgQuest1[5, i].Value.ToString());
            }
            question1.Content = questionlist[0];
            question2.Content = questionlist[1];
            question3.Content = questionlist[2];
            question4.Content = questionlist[3];
            question5.Content = questionlist[4];

            q11.Content = opt1[0];
            q12.Content = opt2[0];
            q13.Content = opt3[0];
            q14.Content = opt4[0];

            q21.Content = opt1[1];
            q22.Content = opt2[1];
            q23.Content = opt3[1];
            q24.Content = opt4[1];

            q31.Content = opt1[2];
            q32.Content = opt2[2];
            q33.Content = opt3[2];
            q34.Content = opt4[2];

            q41.Content = opt1[3];
            q42.Content = opt2[3];
            q43.Content = opt3[3];
            q44.Content = opt4[3];

            q51.Content = opt1[4];
            q52.Content = opt2[4];
            q53.Content = opt3[4];
            q54.Content = opt4[4];
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }

    }
}
