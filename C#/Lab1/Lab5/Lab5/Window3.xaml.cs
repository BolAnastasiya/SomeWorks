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

namespace Lab5
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        //код для перехода между окнами 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
        }
        Class3 class3 = new Class3();//объявление класса
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            { 
                //вывод информации
                Res.Text =class3.Result+ class3.Method1(int.Parse(Hour.Text), int.Parse(Minute.Text), int.Parse(Second.Text)) + class3.Method2(int.Parse(Hour.Text), int.Parse(Minute.Text), int.Parse(Second.Text));
            }
            catch
            {
                MessageBox.Show("Incorrect data!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                //присвоение классовым переменным значения
                class3.Hour = Convert.ToInt32(Hour.Text);
                class3.Minute = Convert.ToInt32(Minute.Text);
                class3.Second = Convert.ToInt32(Second.Text);
                Res.Text = class3.Result;//вывод информации
            }
            catch
            {
                MessageBox.Show("Incorrect data!");
            }
        }
    }
}
