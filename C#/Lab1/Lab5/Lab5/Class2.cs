using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab5
{
    internal class Class2
    {//объявление переменных
        public double l;
        public double v;
        public double h;
        public int count;
        //прописываем свойства с учетом некорректного ввода для каждой переменной
        public double L
        {
            get { return l; }
            set
            {
                if(value < 0|| value ==null)
                    MessageBox.Show("Incorrest data!");
                else
                    l = value;
            }
        }
        public double V
        {
            get { return v; }
            set
            {
                if (value < 0 || value == null)
                    MessageBox.Show("Incorrect data!");
                else
                    v = value;
            }
        }
        public double H
        {
            get { return h; }
            set
            {
                if (value < 0 || value == null)
                    MessageBox.Show("Incorrect data!");
                else
                    h = value;
            }
        }
        public int Count
        {
            get { return count; }
            set
            {
                if (value < 0 || value == null)
                    MessageBox.Show("Incorrect data!");
                else
                    count = value;
            }
        }
        //создаем метод для нахождения площади
        public double Method1()
        {
            return l * v;
        }
        //создаем метод для нахождения объема 
        public double Method2() 
        {
            return l * v * h;
        }
        //создаем свойство для вывода полной информации
        public string Result
        {
            get
            {
                return $"Площадь: {Method1()},\nОбъем: {Method2()},\nКоличество окон: {Count}";
            }
        }
    }
}
