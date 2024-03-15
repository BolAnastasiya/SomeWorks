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

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
        }
        public static int n = 5;
        public static int[,] mass = new int[n, n];//локальный массив

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                TB.Content = "";
                Res.Content = "";
                Random rnd = new Random();
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = rnd.Next(1, 100);//заполняем массив рандомными числами 
                        mass[i, j] = a[i, j];//заполняем локальный массив
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
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
        public int [,]  Method(int[,] res)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j || (i + j + 1) == 5)
                    {
                        res[i, j] = 0;//заменяем в диагоналях значение элементов на нули
                    }
                }
            }
           return  res;
        } 

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int[,] a = Method(mass);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Res.Content += $"{a[i, j]}\t";//выводим строки массива в метку
                }
                Res.Content += "\n\n";//отступаем от предыдущей строки массива
            }
        }
    }
}
