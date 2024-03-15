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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        public Page11()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new Transition());
        }
        static int[] Method(int[] mas)// Метод сортировки пузырьком
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] % 100 < mas[j] % 100)
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        public void Method1()
        {
            int[,] arr = new int[Convert.ToInt32(N.Text), Convert.ToInt32(N.Text)]; //матрица c длиной n
            int a = 0; //счетчик индекса строк массива
            int[] b = new int[Convert.ToInt32(N.Text)]; //создаем массив с длиной n
            string c = TB.Text.Replace('\n', ' ').Replace("\r", ""); // коррекция строки
            while (c.IndexOf("  ") != -1) //удаление двойного пробела
            {
                c = c.Replace("  ", " ");
            }
            string[] arr2 = c.Split(' '); // массив цифр в строковом виде
            try // коректнось данных
            {
                for (int i = 0; i < Convert.ToInt32(N.Text); i++) // заполняем матрицу
                {
                    int sum = 0;
                    for (int j = 0; j < Convert.ToInt32(N.Text); j++)
                    {
                        if (i == j)
                        {
                            arr[i, j] = 0;// делаем диагональ матрицы нулями 
                        }
                        else
                        {
                            arr[i, j] = Convert.ToInt32(arr2[a]);
                            a++;// увеличиваем индекс
                            sum += arr[i, j];// считаем сумму 
                        }
                    }
                    b[i] = i * 100 + sum;//запоминаем номер команды
                }
            }
            catch
            {
                Res.Content = "Ошибка!";
            }
            b = Method(b);//вызываем метод
            for (int i = 0; i < b.Length; i++)
            {
                Res.Content += "Место: " + (i + 1) + " Команда: " + b[i] / 100 + " Баллы: " + b[i] % 100 + "\n";
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Method1();
        }
    }
}
