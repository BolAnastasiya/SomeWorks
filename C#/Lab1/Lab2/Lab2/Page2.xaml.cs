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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public static int[] l = new int[10];
        public Page2()
        {
            InitializeComponent();
            Random r = new Random();
            for (int i = 0; i < l.Length; i++)
            {
                l[i] = r.Next(-9, 10);//заполняем массив
                Mass.Content += $"{l[i]}\t";//выводим массив
            }
        }
        public string Method()
        {
            int sum = 0;
            int count = 0;
            int coun = 0;
            for (int i = 0; i < l.Length; i++)
            {
                if(l[i] <0)
                {
                    sum+=l[i];//находим сумму отрицательных элементов
                    if (l[i] % 2 == 0)
                    {
                        count++;//считаем количество четных отрицательных элементов
                    }
                }
                if(l[i] < -5 || l[i] > 5)
                {
                    coun++;//находим количество элементов, которые по модулю больше 5
                }
            }
            return $"Сумма отрицательных чисел: {sum}\nКоличество четных отрицательных чисел: {count}\nКоличество чисел модуль которых больше 5: {coun}";//возвращаем все данные
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res.Content = Method();//вызываем метод
        }
    }
}
