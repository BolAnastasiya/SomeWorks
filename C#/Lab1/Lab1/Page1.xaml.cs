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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
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
                char a = 'п';
                char A = 'П';
                char b = 'р';
                char B = 'Р';
                if (TB.Text.Length > TB2.Text.Length)
                {
                    int i = TB.Text.Count(f => (f == a || f == A));//считается количество определенного символа в строке
                    int j = TB2.Text.Count(f => (f == b || f == B));
                    Res.Content = $"В длинной строке {i} букв {"п"}, а в короткой строке {j} букв {"р"}";
                }
                else
                {
                    int j = TB.Text.Count(f => (f == b || f == B));
                    int i = TB2.Text.Count(f => (f == a || f == A));
                    Res.Content = $"В длинной строке {i} букв {"п"}, а в короткой строке {j} букв {"р"}";
                }
            }
            catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
                TB2.Text = "";
            }
        }

       
    }
}
