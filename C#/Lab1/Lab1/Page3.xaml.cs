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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = "";
                string s1 = "";
                s = TB.Text.Substring(0, TB.Text.IndexOf('.'));//выделяем первую подстроку до . 
                s = s.Replace(",", "");//в первой построке удаляем все запятые 
                s = s.Replace("-", "+");//в первой подстроке заменяем все - на +
                s1 = TB.Text.Substring(TB.Text.IndexOf('.'));//выделяем вторую подстроку после .
                s1 = s1.Replace("-", "+");//во второй подстроке заменяем все - на +
                Res.Content = $"{s}{s1}";

            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
            }
        }
    }
}
