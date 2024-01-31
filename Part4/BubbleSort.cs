using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movsar_part4
{
    internal class BubbleSort
    {
        public static void Sort(int[] array)
        {
            //Создаем булевую переменную для флажка
            bool b = false;

            //Перебираем массив
            for (int i = 0; i < array.Length - 1; i++)
            {
                //Узнаем нужно ли отсортировать два элемента
                if (array[i] > array[i + 1])
                {
                    //Создаем временную переменную для хранения значения текущего элемента
                    int a = array[i];

                    //Присваиваем текущему элементу значение следующего элемента
                    array[i] = array[i + 1];

                    //Присваиваем следующему элементу значение из временной переменной 
                    array[i + 1] = a;

                    //Ставим флаг что бы знать что была произведена сортировка
                    b = true;
                }
            }
            //Смотрим на флаг и проверяем была ли проведена сортировка
            if (b == true)
            {
                //Если да, то повторяем метод
                Sort(array);
            }
        }
        public static void Start()
        {
            //Создаем массив из случайных чисел
            int[] array = { 2, 10, 3, 5, 4 };

            //Переходим в метод для сортировки массива
            Sort(array);
            Console.WriteLine(string.Join(", ", array));

        }
    }
}
