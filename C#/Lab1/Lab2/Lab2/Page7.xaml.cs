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
    /// Логика взаимодействия для Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        public Page7()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
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
                        a[i, j] = rnd.Next(-9, 10);//заполняем массив рандомными числами 
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
        public int[,] Method(int[,] res)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(res[i, j] < 0)//выбирает отрицательный элемент
                    {
                        if (i % 2 == 0 && j % 2 == 0)//выбирает  элемент с четными индуксами
                        {
                            res[i, j] = 1;//меняет на 1 четный отрицательный элемент
                        }
                    }
                }
            }
            return res;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int[,] a = Method(mass);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Res.Content += $"{a[i, j]}\t";//выводим строки матрицы в метку
                }
                Res.Content += "\n\n";//отступаем от предыдущей строки матрицы
            }
        }
    }
}
