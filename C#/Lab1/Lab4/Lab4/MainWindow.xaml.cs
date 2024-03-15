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

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] b = TB.Text.Split(' ');
            int[] arr = new int[b.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(b[i]);
            }
            Class1 class1 = new Class1();
            if (Negative.IsChecked == true)
            {
                Result.Content = class1.NegativeMethod(arr).ToString();
            }
            if (Even.IsChecked == true)
            {
                Result.Content = class1.EvenMethod(arr).ToString();
            }
            if(N.IsChecked == true)
            {
                int n = Convert.ToInt32(NT.Text);
                Result.Content = class1.NMethod(arr,n).ToString();
            }

        }

        private void N_Checked(object sender, RoutedEventArgs e)
        {
            NL.Visibility = Visibility.Visible;
            NT.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] arr = TB1.Text.Split('\r');
            string a = arr[0];//первая строка
            string b = arr[1];//вторая строка
            b = b.Replace("\n", "");
            Class2 class2 = new Class2();
            if(Delete.IsChecked == true)
            {
                Result1.Content = class2.DeleteMethod(a,b);
            }
            if(Add.IsChecked == true)
            {
                Result1.Content = class2.AddMethod(a, b);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void N_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
