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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        private const int CorrectIndex = 1;
        public Window5()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedCount = listBox1.SelectedItems.Count;

            if (selectedCount != 1)
            {
                MessageBox.Show("Выберите только один ответ!");
            }
            else
            {
                int selectedIndex = listBox1.SelectedIndex;

                if (selectedIndex == CorrectIndex)
                {
                    Class1.Count++;
                    MessageBox.Show("Вы ответили правильно!");
                }
                else
                {
                    MessageBox.Show("Вы ответили неправильно!");
                }

                MessageBox.Show("Тест завершен!");
                Window6 testResult = new Window6();
                this.Hide();
                testResult.ShowDialog();
                this.Close();
            }
        }
    }
    
}
