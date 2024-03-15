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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private int questionNumber = 1;
        public Window4()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Cb.SelectedIndex == -1)
            {
                MessageBox.Show("Надо выбрать ответ!");
                return;
            }
           
        }

       

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool isCorrect = false;
            if (questionNumber == 1 && Cb.SelectedIndex == 1)
                isCorrect = true;
            if (questionNumber == 2 && Cb.SelectedIndex == 0)
                isCorrect = true;

            if (isCorrect)
            {
                Class1.Count += 1;
                MessageBox.Show("Вы ответили правильно! Переходим к следующему вопросу.");
            }
            else
            {
                MessageBox.Show("Вы ответили неправильно! Переходим к следующему вопросу.");
            }

            if (questionNumber == 1)
            {
                questionNumber++;
                L1.Content = "В каком городе и стране находится музей Дали?";
                Cb.SelectedIndex = -1;
            }
            else
            {
                Window5 window5 = new Window5();
                this.Hide();
                window5.ShowDialog();
                this.Close();
            }
        }
    }
}
