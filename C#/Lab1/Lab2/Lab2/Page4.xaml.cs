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
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
        public string Method()
        {
            string s = TB.Text;
            string ss = "";
            for (int i = 0; i <= s.Length-1; i++)
            {
                if((i+1) % 3 == 0)
                {
                    ss += $"{s[i]} ";//перезаписываем цифру с пробелом, по условию
                }
                else
                {
                    ss += $"{s[i]}";//перезаписываем цифру
                }
            }
            return ss;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res.Content = Method();//вызываем метод
        }

        
    }
}
