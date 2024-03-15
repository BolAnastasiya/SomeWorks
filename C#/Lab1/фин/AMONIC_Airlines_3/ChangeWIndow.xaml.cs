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

namespace AMONIC_Airlines_3
{
    /// <summary>
    /// Логика взаимодействия для ChangeWIndow.xaml
    /// </summary>
    public partial class ChangeWIndow : Window
    {
        SqlConnect sqlConnect = new SqlConnect();
        List<string> user = new List<string>();
        DataGrid dg_Users = new DataGrid();

        public ChangeWIndow(string userEmail, DataGrid dg)
        {
            InitializeComponent();
            user.Add(userEmail);
            dg_Users = dg;
        }

        private void bt_apply_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_Email.Text))
                MessageBox.Show("Заполните пустые поля.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (String.IsNullOrWhiteSpace(tb_Name.Text))
                MessageBox.Show("Заполните пустые поля.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (String.IsNullOrWhiteSpace(tb_Surname.Text))
                MessageBox.Show("Заполните пустые поля.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if(cb_Office.SelectedIndex == 0)
                MessageBox.Show("Выберите офис.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                string role = string.Empty;
                
                if (rb_user.IsChecked == true)
                    role = "User";
                else
                    role = "Administrator";
                
                string values = "User_Email = '" + tb_Email.Text + "',User_FirstName = '" + tb_Name.Text + "',User_LastName = '" + tb_Surname.Text + "', User_Title = '" + cb_Office.Text + "',User_Role = '" + role + "'";

                sqlConnect.ChangeUser(values, user[0]);

                this.Close();
            }
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeWind_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnect.OpenConnect();

            cb_Office.ItemsSource = sqlConnect.FillingCb();
            sqlConnect.FindUserInfo(user);

            for (int i = 0; i < user.Count; i++)
            {
                switch(i)
                {
                    case 0:
                        tb_Email.Text = user[i];
                        break;
                    case 1:
                        tb_Name.Text = user[i];
                        break;
                    case 2:
                        tb_Surname.Text = user[i];
                        break;
                    case 4:
                        if (user[4] == "User")
                            rb_user.IsChecked = true;
                        else
                            rb_admin.IsChecked = true;
                        break;
                }
            }

            for(int i = 0; i < cb_Office.Items.Count; i++)
                if(cb_Office.Items[i].ToString() == user[3])
                    cb_Office.SelectedIndex = i;
        }

        private void ChangeWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sqlConnect.CloseConnect();
            dg_Users.Focus();
        }
    }
}
