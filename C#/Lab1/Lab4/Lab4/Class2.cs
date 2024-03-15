using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Class2
    {
        public string DeleteMethod(string a, string b)//метод для удаления из первой строки всех букв "я" и добавления их в начало второй строки 
        {
            string aa = "";
            string bb = "";
            char c = 'я';//
            int count = a.Count(f => f == c);//числовая переменная, в которой содержится количество букв "я" в первой строке
            for(int i = 0; i < count; i++)//цикл
            {
                bb += "я";//добавление в начало второй строки букв "я"
            }
            bb += b;//добавление самой строки 
            aa = a.Replace("я","");//удаляем из первой строки все буквы "я"
            string d = aa + '\n' + bb;//записываем результат в строковую переменную
            return d;//возвращаем результат
        }

        public string AddMethod(string a, string b)//метод для добавления в строки "*", если длина строки меньше 10
        {
            if(a.Length < 10)//проверка условия
            {
                a += new string('*', 10 - a.Length);//добавляем к строке "*", чтобы длина строки стала 10
            }
            if (b.Length < 10)//проверка условия
            {
                b += new string('*', 10 - b.Length);//добавляем к строке "*", чтобы длина строки стала 10
            }
            string d = a + '\n' + b;//записываем результат в строковую переменную
            return d;//возвращаем результат
        }
    }
}
