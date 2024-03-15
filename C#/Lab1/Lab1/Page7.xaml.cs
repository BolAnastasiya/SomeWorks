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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] a = TB.Text.Split(' ');//в массив записывается введенные числа без пробелов
                int[] mass = new int [a.Length];//в числовой массив записывается длина массива
                int temp = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    mass[i] = int.Parse(a[i]);//заполнение массива
                }
                for (int i = 0; i < mass.Length; i++)
                {
                    for (int j = 0; j < mass.Length-1; j++)
                    {
                        if (mass[j] >= 0 && mass[j+1]<0)//ищем отрицательные и положительные элементы массива
                        {
                            temp = mass[j];//сортировка методом пузырька
                            mass[j] = mass[j+1];//сортировка методом пузырька
                            mass[j+1] = temp;//сортировка методом пузырка
                        }
                    }
                    Res.Content += mass[i] + " ";//выводится исправленный массив
                }
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
            }
        }
    }
}
