using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string day;
        public string lesson;
        public int lessondb;
        public MainWindow()
        {
            InitializeComponent();
            label.Visibility = Visibility.Hidden;
            ComboD.Visibility = Visibility.Hidden;
            hour.Visibility = Visibility.Hidden;
            labelh.Visibility = Visibility.Hidden;
            labelp.Visibility = Visibility.Hidden;
            ComboN.Visibility = Visibility.Hidden;
            ListF.Visibility = Visibility.Hidden;
            string connectionString = "Data Source=LAPTOP-JVORKJMO; Initial Catalog=colege;Integrated Security = True";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = @"select фамилия from Преподаватель";
            SqlDataReader r = cmd.ExecuteReader();
            ComboB.Items.Clear();
            while(r.Read())
                ComboB.Items.Add(r.GetValue(0));
            r.Close();
           
        }

        private void ListB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListB2.SelectedIndex <= 5)
            {
                if (ListB2.Items.Contains(ListB.SelectedItem) == false)
                {
                    ListB2.Items.Insert(0, ListB.SelectedItem);
                }
              
            }
            if (ListB2.Items.Count > 5)
            {
                ListB2.Items.Remove(ListB.SelectedItem);
                MessageBox.Show("Выберите другого преподавателя", "Слишком много выбранных дисциплин",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ComboB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListB.Items.Contains(ComboB.SelectedItem) == false)
            {
                ListB2.Items.Clear();
                label.Visibility = Visibility.Hidden;
                ComboD.Visibility = Visibility.Hidden;
                hour.Visibility = Visibility.Hidden;
                labelh.Visibility = Visibility.Hidden;
                labelp.Visibility = Visibility.Hidden;
                ComboN.Visibility = Visibility.Hidden;
                ListF.Visibility = Visibility.Hidden;
                string connectionString = "Data Source=LAPTOP-JVORKJMO; Initial Catalog=colege;Integrated Security = True";
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand cmd1 = cnn.CreateCommand();
                cmd1.CommandText = @"select название from Дисциплина  where код_преподавателя is null";
                SqlDataReader r1 = cmd1.ExecuteReader();
                ListB.Items.Clear();
                while (r1.Read())
                    ListB.Items.Add(String.Format("{0}", r1.GetValue(0).ToString()));
                r1.Close();
            }
        }

        private void ListB2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           if(ListB2.Items != null)
           {
                label.Visibility = Visibility.Visible;
                ComboD.Visibility = Visibility.Visible;
                hour.Visibility = Visibility.Visible;
                labelh.Visibility = Visibility.Visible;
            }
        }

        private void ComboD_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch(ComboD.SelectedIndex)
            {
                case 0:
                    day = "понедельник";
                    break;
                case 1:
                    day = "вторник";
                    break;
                case 2:
                    day = "среда";
                    break;
                case 3:
                    day = "четверг";
                    break;
                case 4:
                    day = "пятница";
                    break;
            }

            if(ComboD.Items != null)
            {
                labelp.Visibility = Visibility.Visible;
                ComboN.Visibility = Visibility.Visible;
            }
        }

        private void ComboN_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            switch (ComboN.SelectedIndex)
            {
                case 0:
                    lesson = "1 пара";
                    lessondb = 1;
                    break;
                case 1:
                    lesson = "2 пара";
                    lessondb = 2;
                    break;
                case 2:
                    lesson = "3 пара";
                    lessondb = 3;
                    break;
                case 3:
                    lesson = "4 пара";
                    lessondb = 4;
                    break;
                case 4:
                    lesson = "5 пара";
                    lessondb = 5;
                    break;
            }
            if (ComboN.Items != null)
            {
                ListF.Visibility = Visibility.Visible;
                ListF.Items.Clear();
                string connectionString = "Data Source=LAPTOP-JVORKJMO; Initial Catalog=colege;Integrated Security = True";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = cnn.CreateCommand();
                    cmd.CommandText = @"select код_преподавателя from Преподаватель where фамилия='" + ComboB.SelectedIndex.ToString() + "'";
                    SqlDataReader r = cmd.ExecuteReader();
                    string a = r.ToString();
                    r.Close();

                    SqlCommand cmd1 = cnn.CreateCommand();
                    cmd1.CommandText = @"select код_дисциплины from Дисциплина where название='" + ListB.SelectedIndex.ToString() + "'";
                    SqlDataReader r1 = cmd1.ExecuteReader();
                    string b = r.ToString();
                    r1.Close();

                    SqlCommand cmd2 = cnn.CreateCommand();
                    cmd2.CommandText = $"insert into Расписание values ('{day}', {lessondb}, null, {int.Parse(a)},{int.Parse(b)})";
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = cnn.CreateCommand();
                    cmd3.CommandText = $"select день_недели, код_дисциплины from Расписание where код_преподавателя = (select код_преподавателя from Преподаватель where фамилия= '{ComboB.SelectedIndex}'";
                    SqlDataReader r2 = cmd3.ExecuteReader();
                    while (r2.Read())
                        ListF.Items.Add(String.Format("{0 1}", r2.GetValue(0).ToString(), r2.GetValue(1).ToString()));
                    r2.Close();
                }
            }
        }

        private void ListF_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
