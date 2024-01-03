/*
    Создайте двумерный массив целых чисел размером 3x3 и заполните его значениями. 
    Затем напишите программу, которая вычисляет сумму всех элементов в этом массиве 
    и выводит ее на экран.
*/

internal class ArrayLength
{
    internal static void Start()
    {
        int[,] massiv = {
            {1, 3, 5},
            {2, 4, 6},
            {7, 8, 9}
        };
        int summa = 0;
        for (int i = 0; i <= massiv.Length; i++)
        {
            summa += i;
        }
        Console.WriteLine(summa);
    }
}