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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
        public string Method()
        {

            string [] s = TB.Text.Split('\n');
            int max = Int32.MinValue;
            int k = 0;
            char a = 'a';
            char A = 'A';
            string str = "";
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {  
                count = s[i].Count(f => (f == a || f == A));//считается количество определенного символа в строке
                if (count > max)
                {
                     k = i;//записываем индекс строки
                     str = s[i];//записываем строку
                     max = count;//записываем в переменную максимальное число
                }
                
            }
            return $"{k}\nСтрока: {str}";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res.Content = Method();//вызываем метод
        }
    }
}
