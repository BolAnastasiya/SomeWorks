using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Lab5
{
    internal class Class1
    {//объявление переменных
        public int index;
        public string cityName;
        public string streetName;
        public int houseNumber;
        //прописываем свойства  с учетом некорректного ввода для каждой переменной
       

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                if (value == 0|| value<=0)
                    MessageBox.Show("Incorrect data!");
                else
                    index = value;
            }
        }


        public string CityName
        {
            get
            {
                return cityName;
            }
            set
            {
                if (value == null || value.Length == 0)
                    MessageBox.Show("Incorrect data!");
                else
                    cityName = value;
            }
        }

        public string StreetName
        {
            get
            {
                return streetName;
            }
            set
            {
                if (value == null || value.Length == 0)
                    MessageBox.Show("Incorrect data!");
                else
                    streetName = value;
            }
        }

        public int HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                if (value == 0 || value <0)
                    MessageBox.Show("Incorrect data!");
                else
                    houseNumber = value;
            }
        }

       
        //свойство возращающее всю информацию
        public string Adress
        {
            get
            {
                return $"Индекс: {index},\nГород: {cityName},\nУлица: {streetName},\nДом: {houseNumber}";
            }
          
        }
    }

}
