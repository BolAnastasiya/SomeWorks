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
using System.Text.RegularExpressions;

namespace AMONIC_Airlines_3
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        SqlConnect sqlConnect = new SqlConnect();
        DataGrid dg_Users;

        public AddUserWindow(DataGrid dg)
        {
            InitializeComponent();
            dg_Users = dg;
        }

        private void bt_save_Click(object sender, RoutedEventArgs e)
        {
            Regex email = new Regex(@"(@)(.+)(\.)(.+)$");
            DateTime dateTime;

            if (!DateTime.TryParse(tb_Birthdate.Text, out dateTime))
                MessageBox.Show("Некоректный формат даты.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (DateTime.Now.Year - dateTime.Year <16)
                MessageBox.Show("Некоректный формат даты.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (!email.IsMatch(tb_Email.Text))
                MessageBox.Show("Неверный email.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (String.IsNullOrWhiteSpace(tb_Name.Text) || String.IsNullOrWhiteSpace(tb_Surname.Text) || String.IsNullOrWhiteSpace(pb_password.Password))
                MessageBox.Show("Заполните пустые поля", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (cb_Office.SelectedIndex == 0)
                MessageBox.Show("Выберите офис", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                string values = "('User','" + tb_Email.Text + "','" + pb_password.Password + "','" + tb_Name.Text + "','" + tb_Surname.Text + "','" + cb_Office.SelectedItem.ToString() + "','" + tb_Birthdate.Text + "'," + "1)";
                sqlConnect.AddNewUser(values);

                this.Close();
            }
        }

        private void bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddUserWind_Loaded(object sender, RoutedEventArgs e)
        {
            cb_Office.ItemsSource = sqlConnect.FillingCb("Select Office");
            sqlConnect.OpenConnect();
        }

        private void AddUserWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sqlConnect.CloseConnect();
            dg_Users.Focus();
        }
    }
}
