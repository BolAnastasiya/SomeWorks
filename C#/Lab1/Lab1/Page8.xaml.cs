using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Page8.xaml
    /// </summary>
    public partial class Page8 : Page
    {
        public Page8()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
        public static int[,] mass = new int[4, 3];//локальный массив
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                TB.Content = "";
                Res.Content = "";
                Random rnd = new Random();
                int[,] a = new int[4, 3];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        a[i, j] = rnd.Next(1, 100);//заполняем массив рандомными числами 
                        mass[i, j] = a[i, j];//заполняем локальный массив
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        TB.Content += $"{a[i, j]}\t";//выводим строки массива в метку
                    }
                    TB.Content += "\n\n";//отступаем от предыдущей строки массива
                }
            }
           catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Content = "";
            }
           
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int sum = 0;
                int sum1 = 0;
                double avg;
                int max = Int32.MinValue;//переменная для максимального числа
                int min = Int32.MaxValue;//переменная для минимального числа
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (mass[i, j] > max)
                        {
                            max = mass[i, j];//записываем в переменную максимальное число
                            sum = mass[i, j];//записываем в переменную максимальное число
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (mass[i, j] < min)
                        {
                            min = mass[i, j];//записываем в переменную минимальное число
                            sum1 = mass[i, j];//записываем в переменнуб минимальное число
                        }
                    }
                }

                avg = Convert.ToDouble(sum + sum1) / 2;//считаем среднее арифметическое 
                Res.Content = $"{Math.Round(avg, 2)}";//выводим ответ
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Content = "";
            }
        }
    }
}
