/*
* Задача 2: Поиск элемента (пример)
*
* Создайте двумерный массив строк размером 4x4, содержащий названия различных стран. 
* Запросите у пользователя название страны и напишите программу, которая проверяет, 
* есть ли данная страна в массиве. Если она есть, выведите сообщение о нахождении, 
* иначе - сообщение об отсутствии.
*
*/

internal static class Arrays
{
    internal static void Start()
    {
        string[,] countries = {
            {"Madrid", "Lisabon", "Asdasd", "Rusi"},
            {"Bangkok", "Mexico", "Israel", "Whatever"},
            {"Ichkeri", "Palestina", "Something", "Turkey"},
            {"Malaysia", "Japan", "China", "Iraq"}
        };

        string country = Console.ReadLine();

        for (int rowIndex = 0; rowIndex <= countries.GetUpperBound(0); rowIndex++)
        {
            for (int colIndex = 0; colIndex <= countries.GetUpperBound(1); colIndex++)
            {
                if (countries[rowIndex, colIndex].ToLower() == country.ToLower())
                {
                    Console.WriteLine($"Карийна: {countries[rowIndex, colIndex]}");
                    return;
                }
            }

        }

        Console.WriteLine("Ца карийна");
    }
}