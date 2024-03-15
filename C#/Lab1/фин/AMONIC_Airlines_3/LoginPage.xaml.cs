using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace AMONIC_Airlines_3
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        int count = 0;
        int time = 11;
        DispatcherTimer timer;
        SqlConnect sqlCon = new SqlConnect();
        public LoginPage()
        {
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            sqlCon.OpenConnect();
        }

        private void bt_login_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(tb_email.Text) && string.IsNullOrEmpty(pb_password.Password))
            {
                MessageBox.Show("Поле для ввода логина или пароля не может быть пустым!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

            if (!String.IsNullOrWhiteSpace(tb_email.Text) && !String.IsNullOrWhiteSpace(pb_password.Password))
            {
                string userInfo = sqlCon.CheckLogin(tb_email.Text, pb_password.Password);

                if (userInfo != null)
                {
                    string role = userInfo.Substring(0, userInfo.IndexOf(';'));
                    bool active = userInfo.Substring(userInfo.IndexOf(';') + 1, userInfo.Length - 1 - userInfo.IndexOf(';')) == "True" ? true : false;

                    if (active)
                    {
                        if (role == "User")
                        {
                            MessageBox.Show("Выполнил вход пользователь сервиса AMONIC AIRLINES", "Вход выполнен", MessageBoxButton.OK);
                            NavigationService.Navigate(new UserPage((tb_email.Text)));

                        }
                        else if (role == "Administrator")
                        {
                            MessageBox.Show("Выполнил вход администратор сервиса AMONIC AIRLINES", "Вход выполнен", MessageBoxButton.OK);
                            NavigationService.Navigate(new AdminPage(tb_email.Text));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ваша учетная запись неактивна.Повторите попытку попозже!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
                if (userInfo == null)
                {
                    MessageBox.Show("Ошибка,введен неправльный логин или пароль пользователя/администратора.Проверьте правильнсоть ввода!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    count++;

                    if (count > 3)
                    {
                        MessageBox.Show("Превышены поптыки ввода логина или пароля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        tb_email.IsEnabled = false;
                        pb_password.IsEnabled = false;
                        bt_login.IsEnabled = false;
                        timer = new DispatcherTimer();
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Tick += Timer_Tick;
                        timer.Start();
                        count = 0;

                    }

                }

            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                TBTimer.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);

            }
            else
            {
                TBTimer.Text = " ";
                timer.Stop();
                MessageBox.Show("Вы можете попробовать еще раз!");
                tb_email.IsEnabled = true;
                pb_password.IsEnabled = true;

                bt_login.IsEnabled = true;
                time = 11;

            }

        }
        private void bt_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
