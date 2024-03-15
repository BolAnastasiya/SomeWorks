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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Проверка выбранных ответов
            bool answer1 = A.IsChecked ==true;
            bool answer2 = B.IsChecked == true;
            bool answer3 = C.IsChecked == true;
            bool answer4 = D.IsChecked == true;

            // Проверка, выбран ли хотя бы один ответ
            if (!answer1 && !answer2 && !answer3 && !answer4)
            {
                MessageBox.Show("Надо выбрать хотя бы один ответ!");
                return;
            }

            // Правильные ответы: 1 и 3
            if (answer1 && answer3 && !answer2 && !answer4)
            {
                Class1.Count += 1;
                MessageBox.Show("Вы ответили правильно! Переходим к следующему вопросу.");
                Window3 window3 = new Window3();
                this.Hide();
                window3.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно! Переходим к следующему вопросу.");
                Window3 window3 = new Window3();
                this.Hide();
                window3.ShowDialog();
                this.Close();
            }
        }
    }
}
