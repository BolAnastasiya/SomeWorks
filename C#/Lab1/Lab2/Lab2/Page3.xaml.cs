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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
        public string Method()
        {
            string s = TB.Text.Replace("*", "");//удаляем все *
            string ss = "";
            for(int i = 0; i < s.Length; i++)
            {
                ss += $"{s[i]}{s[i]}";//перезаписываем в новую строку символы с повтором
            }
            return ss;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res.Content = Method();//вызываем метод
        }
    }
}
