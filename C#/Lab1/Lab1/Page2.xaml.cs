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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
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
                s = TB.Text.Substring(TB.Text.IndexOf(';') + 1);// удаляет из строки все символы до первой ;
                s = s.Substring(0, s.LastIndexOf(';'));// удаляет из новой строки все символы после последней ;
                Res.Content = s;

            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
            }
        } 
    }
}
