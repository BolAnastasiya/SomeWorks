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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int h = 0;
                double c = 0;
                string[] s1 = TB.Text.Split(' ');//в маассив добавляется значения из строки без пробела

                int[] a = new int[s1.Length];//в числовой массив добавляется длина строкового массива

                for (int i = 0; i < s1.Length; i++)
                {
                    a[i] = int.Parse(s1[i]);//заполняем массив
                }
                for (int i = 0; i < a.Length; i++)
                {
                    h += a[i];//считается сумма элементов
                }
                c = Convert.ToDouble(h) / Convert.ToDouble(a.Length);//считается среднее значение
                Res.Content = Math.Round(c, 1) + "\n";//выводится среднее значение
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] < c)//проверяется элемент массива
                    {
                        Res.Content += $"{i} ";//выводится только нужный индекс массива
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
    }
}
