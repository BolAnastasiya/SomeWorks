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
    /// Логика взаимодействия для Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        public Page10()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
        public string Method(string s)
        {
            if(s.Length <=1)
                return "yes";
            if (s.Substring(s.Length - 1, 1) == s.Substring(0,1))//проверяем одинаковые ли первый и последний символы
            {
                s = s.Substring(1, s.Length - 1);//выделяем подстроку без первого символа
                return Method(s.Substring(0, s.Length - 1));//возвращаем строку без последнего символа
            }
            else return "no";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res.Content = Method(N.Text);//выводим результат
        }
    }
}
