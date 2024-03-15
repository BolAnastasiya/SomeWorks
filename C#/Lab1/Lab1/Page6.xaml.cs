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
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        public Page6()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int sum = 0;//переменная суммы
                int coun = 0;//переменная количества
                int count = int.Parse(TB.Text);//в переменную записывается введенное число 
                int[] a = new int[count];//создается массив с длиной введенного числа
                string[] b = TB2.Text.Split(' ');//в строковый массив записываются введенные числа
                for (int i = 0; i < b.Length; i++)
                {
                    a[i] = int.Parse(b[i]);//заполняем массив
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] <= 2)
                    {
                        a[i] = 0;//все элементы <2 заменяются на 0
                    }
                    if (a[i] >= 3 && a[i] <= 7)
                    {
                        sum += a[i];//считается сумма на промежутке от 3 до 7
                        coun++;//считается количество элементов на промежутке от 3 до 7
                    }
                    Res.Content += $"{a[i]} ";//выводится исправленный массив 
                }
                Res.Content += $"\nсумма {sum}\nколичество {coun}";//выводятся сумма и количество на промежутке от 3 до 7
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
                TB2.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
    }
}
