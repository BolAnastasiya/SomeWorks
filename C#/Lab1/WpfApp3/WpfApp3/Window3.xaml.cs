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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        private void MoveSelectedItem(ListBox sourceListBox, ListBox destinationListBox)
        {
            if (sourceListBox.SelectedItem != null)
            {
                // Получаем выбранный элемент
                var selectedItem = sourceListBox.SelectedItem;

                // Удаляем выбранный элемент из исходного ListBox
                sourceListBox.Items.Remove(selectedItem);

                // Добавляем выбранный элемент в целевой ListBox
                destinationListBox.Items.Add(selectedItem);
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Перемещение выбранного элемента из одного ListBox в другой
            MoveSelectedItem(listBox, listbox1);

            // Удаление выбранного элемента из listBox
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // Перемещение выбранного элемента из одного ListBox в другой
            MoveSelectedItem(listBox, listbox2);

            // Удаление выбранного элемента из listBox
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // Перемещение выбранного элемента из одного ListBox в другой
            MoveSelectedItem(listBox, listbox3);

            // Удаление выбранного элемента из listBox
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var correctAnswers = new Dictionary<string, string>
    {
        { "Пабло Пикассо", "Один из художников был настолько беден, что растапливал своими картинами печь" },
        { "Серов", "Кто является автором картины «Девочка с персиками»" },
        { "Игорь Грабарь", "Автором картины «Февральская лазурь» является" }    };
           
            var userAnswers = new Dictionary<string, string>
    {
        { "Пабло Пикассо", listbox1.Items.Count > 0 ? listbox1.Items[0].ToString().Replace("System.Windows.Controls.Label: ","") : "" },
        { "Серов", listbox2.Items.Count > 0 ? listbox2.Items[0].ToString().Replace("System.Windows.Controls.Label: ","") : "" },
        { "Игорь Грабарь", listbox3.Items.Count > 0 ? listbox3.Items[0].ToString().Replace("System.Windows.Controls.Label: ","") : "" }
    };

            bool isCorrect = true;
            foreach (var stage in correctAnswers.Keys)
            {
                if (!userAnswers.ContainsKey(stage) || userAnswers[stage] != correctAnswers[stage])
                {
                    isCorrect = false;
                    break;
                }   
            }

            // Проверяем, что все элементы были распределены
            if (listBox.Items.Count > 0)
            {
                MessageBox.Show("Не все элементы были распределены.");
                return;
            }

            // Показываем результат
            if (isCorrect)
            {
                Class1.Count += 1;
                MessageBox.Show("Вы правильно установили все соответствия! \nПереходим к следующему вопросу.");
                Window4 window4 = new Window4();
                this.Hide();
                window4.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Одно или несколько соответствий установлено неверно. \nПереходим к следующему вопросу.");
                Window4 window4 = new Window4();
                this.Hide();
                window4.ShowDialog();
                this.Close();
            }
        }
    }
}
