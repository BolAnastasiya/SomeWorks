using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace Lab6
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
            Res1.Text = "";
            StreamReader streamReader = new StreamReader("test.txt");
            string s = streamReader.ReadToEnd();//читаем из файла данные
            string[] ss = s.Split(' ');//убираем пробелы
            int[] arr = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                arr[i] = Convert.ToInt32(ss[i]);//записываем в массив числа
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    Res1.Text += $"{arr[i]} ";//выводим результат
                }
            }
            streamReader.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            StreamReader streamReader = new StreamReader("test1.txt");
            string s = streamReader.ReadToEnd();//читаем из файла данные
            string[] ss = s.Split(' ');//убираем пробелы
            for (int i = 0; i < ss.Length; i++)
            {
                if (i == ss.Length - 1)
                    ss[i] = TB1.Text;//записываем в массив числo
            }
            streamReader.Close();
            StreamWriter streamWriter = new StreamWriter("test1.txt");
            for (int i = 0; i < ss.Length; i++)
            {
                streamWriter.Write($"{ss[i]} ");
            }
            streamWriter.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            // Создаем файлы для записи четных и отрицательных чисел
            string evenNumbersFilePath = "even.txt";
            string negativeNumbersFilePath = "negative.txt";

            StreamReader streamReader = new StreamReader("test2.txt");
            string s = streamReader.ReadToEnd();//читаем из файла данные
            string[] ss = s.Split(' ');//убираем пробелы
            int[] arr = new int[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                arr[i] = Convert.ToInt32(ss[i]);//записываем в массив числа
            }
            for (int i = 0; i < arr.Length; i++)
            {
                // Если число четное, записываем его в файл с четными числами
                if (arr[i] % 2 == 0)
                {
                    using (StreamWriter writer = new StreamWriter(evenNumbersFilePath, true))
                    {
                        writer.WriteLine(arr[i]);
                    }
                }
                // Если число отрицательное, записываем его в файл с отрицательными числами
                if (arr[i] < 0)
                {
                    using (StreamWriter writer = new StreamWriter(negativeNumbersFilePath, true))
                    {
                        writer.WriteLine(arr[i]);
                    }
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            string outputFile = "output.txt";//создание файла для записи
            // Открыть файл для чтения
            StreamReader reader = new StreamReader("test3.txt");
            string s = reader.ReadToEnd();//читаем из файла данные
            // Открыть файл для записи
            StreamWriter writer = new StreamWriter(outputFile);
            writer.Write(string.Join("", s.Reverse().ToArray()));
            // Закрыть файлы
            reader.Close();
            writer.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            // Задаем путь к файлу
            string path = "test4.txt";

            // Читаем файл построчно и подсчитываем количество символов в каждой строке
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int charCount = line.Length;
                    Res1.Text += $"Количество символов в строке \"{line}\" равно {charCount}\n";
                }
                // Закрыть файлы
                reader.Close();
            }


        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            // Имя и путь к файлу, который нужно обработать
            string inputFile = "test5.txt";

            // Имя и путь к файлу, в который будет записан результат
            string outputFile = "output.txt";

            // Читаем все строки из исходного файла в массив строк
            string[] lines = File.ReadAllLines(inputFile);

            // Находим первую строку, которая заканчивается на вопросительный знак
            int indexToRemove = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].EndsWith("?"))
                {
                    indexToRemove = i;
                    break;
                }
            }

            // Если найдена строка для удаления, создаем новый массив строк без нее
            if (indexToRemove != -1)
            {
                string[] newLines = new string[lines.Length - 1];
                for (int i = 0, j = 0; i < lines.Length; i++)
                {
                    if (i != indexToRemove)
                    {
                        newLines[j++] = lines[i];
                    }
                }

                // Записываем новый массив строк в выходной файл
                File.WriteAllLines(outputFile, newLines);
            }
            else
            {
                // Если строка для удаления не найдена, просто копируем исходный файл в выходной файл
                File.Copy(inputFile, outputFile);
            }

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            string path = "test6.txt"; // путь к файлу


            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null) // читаем строки по очереди
                {
                    if (line.Contains("   ")) // проверяем, есть ли 3 и более подряд пробела
                    {
                        Res1.Text += line + "\n"; // выводим строку на экран
                    }
                }
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            string path = "test7.txt"; // путь к файлу
            int maxLength = 0; // переменная для хранения максимальной длины строки
            string longestLine = ""; // переменная для хранения самой длинной строки


            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null) // читаем строки по очереди
                {
                    if (line.Length > maxLength) // если длина текущей строки больше максимальной
                    {
                        maxLength = line.Length; // обновляем значение максимальной длины
                        longestLine = line; // сохраняем текущую строку как самую длинную
                    }
                }
            }
            Res1.Text = "Самая длинная строка: " + longestLine; // выводим найденную строку на экран
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Res1.Text = "";
            string path = "g.txt"; // путь к файлу

            Dictionary<string, List<double>> employees = new Dictionary<string, List<double>>(); // словарь для хранения информации о сотрудниках
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null) // читаем строки по очереди
                {
                    string[] fields = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // разбиваем строку на поля, удаляя пустые элементы

                    string lastName = fields[0]; // фамилия сотрудника
                    string position = fields[14]; // должность сотрудника
                    double salarySum = 0; // суммарная зарплата за год
                    for (int i = 2; i <= 13; i++) // проходим по полям со зарплатой
                    {
                        double salary;
                        if (double.TryParse(fields[i], out salary)) // если поле можно преобразовать в число
                        {
                            salarySum += salary; // добавляем зарплату к сумме
                        }
                    }

                    if (!employees.ContainsKey(lastName)) // если такой сотрудник еще не встречался в файле
                    {
                        employees[lastName] = new List<double>(); // добавляем его в словарь
                    }
                    employees[lastName].Add(salarySum); // добавляем информацию о зарплате за год

                }
            }

            List<string> employeeNames = new List<string>(employees.Keys);
            employeeNames.Sort(); // сортируем фамилии сотрудников по алфавиту
            foreach (string name in employeeNames)
            {
                double averageSalary = employees[name].Average() / 12; // вычисляем среднегодовую зарплату
                Res1.Text +=$"{name}: {Math.Round(averageSalary, 2):C}\n"; // выводим информацию на экран
            }
        }
    }
}

