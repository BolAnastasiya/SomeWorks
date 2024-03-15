using System;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Diagnostics;

namespace AMONIC_Airlines_3
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        SqlConnect sqlConnect = new SqlConnect();
        string email;

        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();
        string currentTime = string.Empty;
        string loginTime = string.Empty;
        string loginDate = string.Empty;

        public UserPage(string em)
        {
            InitializeComponent();

            email = em;
        }

        private void ExitMenuBt_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FrameNavigate.RemovePage();
            sqlConnect.OpenConnect();

            sqlConnect.FindActiveSession(email);

            lb_inscription.Content = "Hi, " + sqlConnect.FindUserName(email) + ", Welcome to  AMONIC Airlines";
            lb_crash.Content = "Number of crashes " + sqlConnect.FindUserCrashes(email);

            dg_User_Info.ItemsSource = sqlConnect.FindUserTime(email).AsDataView();

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;

            timer.Start();
            stopwatch.Start();

            loginTime = DateTime.Now.ToString("HH:mm:ss");
            loginDate = DateTime.Now.ToString("yyyy-MM-dd");
           

            sqlConnect.AddNewUserSession("'" + email + "','" + loginDate + "','" + loginTime + "',null,null,null,0");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                lb_time.Content = currentTime;
            }
        }

        public void SaveData()
        {
            string values = "User_Logout_Time = '" + DateTime.Now.ToString("hh:mm:ss") + "', User_Time_Spent = '" + currentTime + "', User_Crash = 0";
            sqlConnect.UpdateUserTimeInfo(values, loginDate, loginTime);
        }

        private void Broke_Click(object sender, RoutedEventArgs e)
        {
            Convert.ToInt32("string");
        }
    }
}
