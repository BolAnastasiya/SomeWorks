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
                        a[i, j] = rnd.Next(1, 21);//заполняем массив рандомными числами 
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
        public string Method(int[,] res)
        {
            int sum = 0;
            int min = Int32.MaxValue;//переменная для минимального числа
            for (int i = 0; i < n; i++)
            {
                min = 1000;//обнуление максимальной переменной
             
                for (int j = 0; j < n; j++)
                {
                    if (mass[i, j] < min)
                    {
                        min = mass[i, j];//записываем в переменную минимальное число
                    }
                }
                sum += min;//находим сумму
            }
            return $"Сумма минимальных элементов: {sum}";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
             Res.Content = Method(mass);//выводим результат
           
        }
    }
}
