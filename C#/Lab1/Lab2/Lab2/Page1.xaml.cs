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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public static int[] l = new int[10];
        public Page1()
        {
            InitializeComponent();
            Random r = new Random();
            for(int i = 0; i < l.Length; i++)
            {
                l[i] = r.Next(1, 10);//рандомным образом заполняем массив
                Mass.Content += $"{l[i]}\t";//выводим массив в метку
            }

        }

        public int Method()
        {
            int n = int.Parse(N.Text);//заданное число записываем в переменную
            int count = 0;
            for(int i = 0; i < l.Length; i++)
            {
                if(l[i] == n)
                    count++;//считаем количество, подходящих нам элементов
            }
            return count;//выходим из цикла, найдя все подходящие элементы
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
