using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab5
{
    internal class Class3
    {
        //объявление переменных
        public int hour;
        public int minute;
        public int second;
        //прописываем свойства для каждой переменной с учетом некорректности ввода
        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 23)
                    MessageBox.Show("Incorrect data!");
                else
                {
                    hour = value;
                }
            }

        }
        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 0 || value > 59)
                    MessageBox.Show("Incorrect data!");
                else
                {
                    minute = value;
                }
            }

        }
        public int Second
        {
            get { return second; }
            set
            {
                if (value < 0 || value > 59)
                    MessageBox.Show("Incorrect data!");
                else
                {
                    second = value;
                }
            }

        }
        //создаем метод для нахождения будущего времени
        public string Method1(int h, int m, int s)
        {
            if(h < 24 && h >= 0 && m >= 0 && m < 60 && s >= 0 && s < 60)
            {
                int sumh = hour + h;
                int summ = minute + m;
                int sums = second + s;
                if (sums >= 60)
                {
                    sums -= 60;
                    summ += 1;
                }
                if (summ >= 60)
                {
                    summ -= 60;
                    sumh += 1;
                }
                if (sumh >=24)
                    sumh -=24;
                return $"Сложение: {sumh:D2} : {summ:D2} : {sums:D2}\n";
            }
            else
            {
                return "Incorrect data!";
            }
        }
        //создаем метод для нахождения прошедшего времени
        public string Method2(int h, int m, int s)
        {
            if (h < 24 && h >= 0 && m >= 0 && m < 60 && s >= 0 && s < 60)
            {
                int subh = hour - h;
                int subm = minute - m;
                int subs = second - s;
                if (subs < 0)
                {
                    subs += 60;
                    subm -= 1;
                }
                if (subm < 0)
                {
                    subm += 60;
                    subh -= 1;
                }
                if (subh < 0)
                    subh += 24;
                return $"Вычитание: {subh:D2} : {subm:D2} : {subs:D2},\n";
            }
            else
            {
                return "Incorrect data!";
            }
        }
        //создаем свойство для вывода информации о времени
        public string Result
        {
            get
            {
                return $"Время: {Hour:D2} : {Minute:D2} : {Second:D2},\n";
            }
        }
    }
}
