using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<StudentsGroup> students = new ObservableCollection<StudentsGroup>();
        private string filePath = "students.txt";

        public class StudentsGroup
        {
            //Создание переменых
            private string name;
            private string surname;
            private DateTime? birthdate;

            //Прописываем свойства для переменных
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Surname
            {
                get { return surname; }
                set { surname = value; }
            }

            public DateTime? Birthdate
            {
                get { return birthdate; }
                set { birthdate = value; }
            }
        }
        private void LoadDataFromFile()
        {
            if (File.Exists(filePath)) //Существует ли файл
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) //Читаем строки из файла
                        {
                            string[] parts = line.Split(','); //Разделяем строку из файла на части в массив
                            if (parts.Length == 3)
                            {
                                students.Add(new StudentsGroup
                                {
                                    Name = parts[0],
                                    Surname = parts[1],
                                    Birthdate = DateTime.Parse(parts[2])
                                }); //Добавляем в класс Students нового студента
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data from file: {ex.Message}"); //При ошибке выдается исключение
                }
            else MessageBox.Show("Файл не найден!", "Ошибка"); //При ошибке выдается исключение
        }

        /// <summary>
        /// Метод сохраняет новые данные в файл
        /// </summary>
        private void SaveDataToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var student in students)
                        writer.WriteLine($"{student.Surname},{student.Name},{student.Birthdate:dd-MM-yyyy}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data to file: {ex.Message}");
            }
        }

        //очищаем поля от заполнения
        private void ClearInputs()
        {
            TBName.Text = string.Empty;
            TBSurname.Text = string.Empty;
            DP.SelectedDate = null;
        }
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
            LoadDataFromFile(); //Метод загрузки данных из файла в коллекцию
            Data.ItemsSource = students;
        }
        //Кнопка для добавления нового студенты
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TBName.Text == string.Empty || TBSurname.Text == string.Empty || DP.SelectedDate == null)
                {
                    MessageBox.Show("Неверный формат");
                }
                else
                {
                    int age = DateTime.Today.Year - Convert.ToDateTime(DP.SelectedDate).Year;//Переменная для проверки возраста студента
                    if (Convert.ToDateTime(DP.SelectedDate).AddYears(age) > DateTime.Today)
                        age--;

                    if (age >= 15)
                    {
                        //Добавляем студента в список
                        students.Add(new StudentsGroup
                        {
                            Name = TBName.Text,
                            Surname = TBSurname.Text,
                            Birthdate = DP.SelectedDate
                        });

                        SaveDataToFile();//добавляем в файл
                        ClearInputs();//очищаем поля
                    }
                    else MessageBox.Show("Студенту должно быть 15 и больше!");
                }
               
            }
            catch
            {
                MessageBox.Show("Неверный формат");
            }

        }
        //Кнопка для удаления студента
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Data.SelectedItem != null)
            {
                students.Remove(Data.SelectedItem as StudentsGroup);//удаление студента 
                SaveDataToFile();//сохраняем данные
            }
        }
        //Кнопка для сортировки студентов
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<StudentsGroup> sortedStudents;

            switch (Cb.SelectedIndex)
            {
                case 0:
                    sortedStudents = students.OrderBy(s => s.Name).ToList();//Сортировка студентов по имени
                    break;
                case 1:
                    sortedStudents = students.OrderBy(s => s.Surname).ToList();//Сортировка студентов по фамилии
                    break;
                case 2:
                    sortedStudents = students.OrderBy(s => s.Birthdate).ToList();//Сортировка студентов по дате рождения
                    break;
                default:
                    sortedStudents = students.ToList();//Выполняется, если не подходит не одно из условий 
                    break;
            }

            Data.ItemsSource = new ObservableCollection<StudentsGroup>(sortedStudents);//вывод результата
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        //Кнопка для вывода списка студентов
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Data.ItemsSource = students;//Выводит всех студентов 
        }
        //Кнопка для нахождения студентов
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string search = TBSearch.Text.ToLower();
            
            var searchResults = students.Where(s =>
                s.Name.ToLower().Contains(search)// ||//поиск студента по имени
                //s.Surname.ToLower().Contains(search) ||//поиск студента  по фамилии
                //(s.Birthdate.HasValue && s.Birthdate.Value.ToString("yyyy-MM-dd").Contains(search))//поиск студента по дате рождения
            );

            Data.ItemsSource = searchResults;//Вывод результата
        }
    }
}
