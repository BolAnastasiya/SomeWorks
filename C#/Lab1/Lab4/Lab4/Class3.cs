using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab4
{
    internal class Class3
    {
        public class MyClass
        {

            private readonly int[] arr; //целочисленный массив
            private readonly int n; //индекс

            // Конструктор
            public MyClass(int i)//заполнение массива рандомными цифрами, длиной n
            {
                arr = new int[i];
                Random r = new Random();
                for (int j = 0; j < i; j++)
                {
                    arr[j] = r.Next(0,10);
                }
                n = i;
            }
            
            //Получение значения по индексу
            public int GetIndex(int i)
            {
                int number;
                if (i >= n || i < 0)
                {
                    throw new Exception("Индекс выходит за границы массива");//Исключение если индекс выходит за границы массива
                }
                else
                {
                    number = arr[i]; //записывает элемент массива
                }
                return number; //Вывод элемента массива с данным индексом
            }
            public int Index
            {
                get { return n; }

            }
            public int this[int nn]// индексатор
            {
                get
                {
                    if (nn >= n)
                    {
                        throw new IndexOutOfRangeException();// исключение
                    }
                    else
                        return arr[nn];
                }
                set
                {
                    if (nn >= n)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    else
                        arr[nn] = value;
                }
            }
            //Сложение векторов
            public static MyClass operator +(MyClass x, MyClass y)// определение операции +
            {
                if (x.Index != y.Index)
                {
                    throw new ArgumentException("Разная длина массивов");// исключение
                }
                else
                {
                    MyClass temp = new MyClass(x.Index);
                    for (int i = 0; i < temp.Index; i++)
                    {
                        temp[i] = x[i] + y[i];
                    }
                    return temp;
                }
            }

            public MyClass Arr (MyClass x, MyClass y)// определение операции +
            {
                if (x.Index != y.Index)
                {
                    throw new ArgumentException("Разная длина массивов");// исключение
                }
                else
                {
                    MyClass temp = new MyClass(x.Index);
                    for (int i = 0; i < temp.Index; i++)
                    {
                        temp[i] = x[i] + y[i];
                    }
                    return temp;
                }
            }
            //Вычитание векторов
            public static MyClass operator -(MyClass x, MyClass y)//определение операции -
            {
                if (x.Index != y.Index)
                {
                    throw new ArgumentException("Разная длина массивов");// исключение
                }
                else
                {
                    MyClass temp = new MyClass(x.Index);
                    for (int i = 0; i < temp.Index; i++)
                    {
                        temp[i] = x[i] - y[i];
                    }
                    return temp;
                }
            }
            //Деление на скаляр
            public static MyClass operator /(MyClass x, double s)// определение операции /
            {
                MyClass temp = new MyClass(x.Index);
                for (int i = 0; i < temp.Index; i++)
                {
                    temp[i] = Convert.ToInt32(Convert.ToDouble(x[i]) / s);
                }
                return temp;
            }
            //Умножение на скаляр
            public static MyClass operator *(MyClass x, double s)// определение операции*
            {
                MyClass temp = new MyClass(x.Index);
                for (int i = 0; i < temp.Index; i++)
                {
                    temp[i] = Convert.ToInt32(Convert.ToDouble(x[i]) * s);
                }
                return temp;
            }
            public string Output()//вывод массива на экран
            {
                string s = "";
                for (int i = 0; i < n; i++)
                {
                    s += $"{arr[i]}  ";
                }
                return s;
            }
            public string OutputN(int nnn)//вывод на экран элемента массива по заданному индексу 
            {
                string s = "";
                for (int i = 0; i < n; i++)
                    s += $"{arr[nnn]}  ";
                return s;
            }
        }
    }
}

