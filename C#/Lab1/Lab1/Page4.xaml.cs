using System.Windows;
using System.Windows.Controls;

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TB2.Text.Length > 30)//проверяется длина второй строки, если она больше 30 символов, то выполняется цикл
                {
                    for (int i = 0; i < TB.Text.Length; i++)
                    {
                        if (i % 2 != 0)//проверка на нечетность
                        {
                            Res.Content += $"{TB.Text[i]}";//добавление нечетного элемента в строку
                        }
                    }
                }
                if (TB.Text.Length < 15)//проверяется длина первой строки, если она меньше 15 символов, то выполняется цикл
                {
                    for (int i = 0; i < TB2.Text.Length; i++)
                    {
                        if (i % 2 == 0)//проверка на четность 
                        {
                            Res.Content += $"{TB2.Text[i]}";//добавление четного элемента в строку
                        }
                    }
                }
            }
           catch
            {
                MessageBox.Show("Некорректные данные");
                TB.Text = "";
                TB2.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
    }
}
