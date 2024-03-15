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
    /// Логика взаимодействия для Page9.xaml
    /// </summary>
    public partial class Page9 : Page
    {
        public Page9()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());

        }
        public static int m ;
        public static int n;
        public static int[,] mass = new int[m, n];//локальный массив
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                m = int.Parse(M.Text);
                n = int.Parse(N.Text);
                TB.Content = "";
                Res.Content = "";
                Random rnd = new Random();
                int[,] a = new int[m, n];
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = rnd.Next(1, 100);//заполняем массив рандомными числами 
                    }
                }
                mass = a;//заполняем локальный массив

                for (int i = 0; i < m; i++)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {   
                int min = Int32.MaxValue;//переменная для минимального числа
                for (int i = 0; i < m; i++)
                {
                    min = 1000;//обнуление минимального числа
                    for (int j = 0; j < n; j++)
                    {
                        if (mass[i, j] < min)
                        {
                            min = mass[i, j];//записываем в переменную минимальное число
                        }
                    }
                    Res.Content += min.ToString() + " ";//выводим переменную
                }
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Content = "";
            }
        }
    }
}
