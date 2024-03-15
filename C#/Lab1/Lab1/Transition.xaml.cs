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
    /// Логика взаимодействия для Transition.xaml
    /// </summary>
    public partial class Transition : Page
    {
        public Transition()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page2());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page3());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page4());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page5());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page6());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page7());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page8());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page9());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page10());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page11());
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Page1());
        }
    }
}
