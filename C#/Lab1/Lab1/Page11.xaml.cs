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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        public Page11()
        {
            InitializeComponent();
        }
        public static int[,] mass = new int[3, 4];//локальный массив
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int sum = 0;
                int sum1 = 0;
                int max = Int32.MinValue;//переменная для максимального числа
                int min = Int32.MaxValue;//переменная для минимального числа
                for (int i = 0; i < 4; i++)
                {
                    if (mass[2, i] > max)
                    {
                        max = mass[2, i];//записываем в переменную максимальное число
                        sum = mass[2, i];//записываем в переменную максимальное число
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (mass[2, i] < min)
                    {
                        min = mass[2, i];//записываем в переменную минимальное число
                        sum1 = mass[2, i];//записываем в переменнуб минимальное число
                    }
                }
                Res.Content = sum + sum1;//выводим сумму
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Content = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                TB.Content = "";
                Res.Content = "";
                Random rnd = new Random();
                int[,] a = new int[3, 4];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        a[i, j] = rnd.Next(1, 100);//заполняем массив рандомными числами 
                        mass[i, j] = a[i, j];//заполняем локальный массив
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
    }
}
