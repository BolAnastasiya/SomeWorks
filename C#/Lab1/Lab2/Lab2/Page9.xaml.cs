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

        public string Method(string s)
        {
            if (s.Length == 1) return s.Substring(0,1);//добавляем первый символ
            return s.Substring(s.Length-1,1) + " " + Method(s.Substring(0,s.Length-1));//добавляем последний символ с пробелами
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res.Content = Method(N.Text);//выводим результат
        }
    }
}
