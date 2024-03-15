using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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
        Class1 class1 = new Class1();//объявление класса

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                string[] s = TB1.Text.Split(' ');
                //заполнение классовых переменных значениями
                class1.Index = Convert.ToInt32(s[0]);
                class1.CityName = s[1];
                class1.StreetName = s[2];
                class1.HouseNumber = int.Parse(s[3]);
                Res.Text = class1.Adress;//вывод информации 
            }
            catch
            {
                MessageBox.Show("Incorrect data!");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //изменение данных 
                if (Ind.Text != "")
                {
                    if (Regex.IsMatch(Ind.Text, @"^\d{6}$"))
                    {
                        class1.Index = int.Parse(Ind.Text);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect data!");
                    }
                }
                if (Str.Text != "")
                {
                    class1.StreetName = Str.Text;
                }
                if (Cit.Text != "")
                {
                    class1.CityName = Cit.Text;
                }
                if (Hou.Text != "")
                {
                    class1.HouseNumber = int.Parse(Hou.Text);
                }

                Res.Text = class1.Adress;//вывод информации 

            }
            catch
            {
                MessageBox.Show("Incorrect data!");
            }


        }
    }
}
