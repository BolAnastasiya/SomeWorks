using System;
using System.Collections.Generic;
using System.Data;
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

namespace AMONIC_Airlines_3
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        SqlConnect sqlConnect = new SqlConnect();
        bool refreshDG = false;
        string mail;

        public AdminPage(string a)
        {
            mail = " User_Email = '"+a+"'";
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUser = new AddUserWindow(dg_Users);
            refreshDG = true;
            addUser.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FrameNavigate.RemovePage();
            sqlConnect.OpenConnect();

            cb_offices.ItemsSource = sqlConnect.FillingCb("All Offices");
        }

        private void cb_offices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshDG();
        }

        private void bt_EnDiLogin_Click(object sender, RoutedEventArgs e)
        {
            if(dg_Users.SelectedItems.Count > 0 )
            {
                string userEmails = string.Empty;

                for (int i = 0; i < dg_Users.SelectedItems.Count; i++)
                {
                    if (i != dg_Users.SelectedItems.Count - 1)
                        userEmails += " User_Email = '" + ((DataRowView)dg_Users.SelectedItems[i]).Row["User_Email"].ToString() + "'" + " or ";
                    else
                        userEmails += " User_Email = '" + ((DataRowView)dg_Users.SelectedItems[i]).Row["User_Email"].ToString() + "'";
                }
                if(mail!= userEmails)
                sqlConnect.EnableOrDisableLogin(userEmails);

                RefreshDG();
            }
        }

        public void RefreshDG()
        {
            dg_Users.ItemsSource = null;

            if (cb_offices.SelectedIndex == 0)
            {
                dg_Users.ItemsSource = sqlConnect.FindAllUsersInfo().AsDataView();
            }
            else
            {
                dg_Users.ItemsSource = sqlConnect.FindByOfficesUsersInfo(cb_offices.SelectedItem.ToString()).AsDataView();
            }
        }

        private void dg_Users_GotFocus(object sender, RoutedEventArgs e)
        {
            if(refreshDG)
            {
                refreshDG = false;
                RefreshDG();
            }
        }

        private void bt_changeRole_Click(object sender, RoutedEventArgs e)
        {
            if(dg_Users.SelectedItems.Count == 1 )
            {
                string userEmail = ((DataRowView)dg_Users.SelectedItems[0]).Row["User_Email"].ToString();
                refreshDG = true;
                ChangeWIndow changeWIndow = new ChangeWIndow(userEmail, dg_Users);
                changeWIndow.ShowDialog();
            }
            else
                MessageBox.Show("Выберите хотя бы одного сотрудника.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
