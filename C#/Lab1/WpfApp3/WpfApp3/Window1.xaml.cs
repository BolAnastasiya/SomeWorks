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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (A.IsChecked == false & B.IsChecked ==false & C.IsChecked == false & D.IsChecked==false)
            {
                MessageBox.Show("Надо ответить на вопрос!");
                return;
            }
            if (B.IsChecked == true)
            {
                Class1.Count +=1;
                MessageBox.Show("Вы ответили правильно! Переходим к следующему вопросу.");

            }
            else
            {
                MessageBox.Show("Вы ответили неправильно! Переходим к следующему вопросу.");

            }
            Window2 window2= new Window2();
            this.Hide();
            window2.ShowDialog();
            this.Close();
        }
    }
}
