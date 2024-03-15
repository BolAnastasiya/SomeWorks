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
using static Lab4.Class3;

namespace Lab4
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
        MyClass a ;
        MyClass b ;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int l = int.Parse(TB.Text);
            MyClass myClass = new MyClass(l);   
            switch(Combo.SelectedIndex)
            {
                case 1:
                    int n = int.Parse(Index.Text);
                    Result.Content = myClass.Output() + "\n" +  myClass.GetIndex(n).ToString();
                    break;
                case 2:

                   // Result.Content = myClass +  ;
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
            }
        }

        private void ComboBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (Combo.SelectedIndex)
            {
                case 1:
                    label.Visibility = Visibility.Visible;
                    Index.Visibility = Visibility.Visible;
                    btn.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    label.Visibility = Visibility.Hidden;
                    Index.Visibility = Visibility.Hidden; 
                    btn.Visibility = Visibility.Visible;
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
            }
        } 

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int l = int.Parse(TB.Text);
            MyClass aa = new MyClass(l);
            int ll = int.Parse(TB.Text);
            MyClass bb = new MyClass(ll);
            a = aa;
            b = bb;
        }
    }
}
