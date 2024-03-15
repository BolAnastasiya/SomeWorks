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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Class2 class2 = new Class2();//объявление класса

            try
            {
                //заполнение классовых переменных значениями
                class2.L = Convert.ToDouble(L.Text);
                class2.V = Convert.ToDouble(V.Text);
                class2.H = Convert.ToDouble(H.Text);
                class2.Count = Convert.ToInt32(Cou.Text);
                Res.Text = class2.Result;//вывод информации на экран
                //проверка на правильность написания
                MessageBoxResult res = MessageBox.Show("Все верно?", "Проверьте правильность введенных данных", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    //если данные верны
                    L.IsEnabled = false;
                    V.IsEnabled = false;
                    Cou.IsEnabled = false;
                    H.IsEnabled = false;

                }
                else
                {
                    //если хотим изменить данные
                    Res.Text = "";
                    L.IsEnabled = true;
                    H.IsEnabled = true;
                    Cou.IsEnabled = true;
                    V.IsEnabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Incorrect data!");
            }
        }
    }
}
