internal static class WhileDoWhile
{
    internal static void Start()
    {
        Task3();
    }

    private static void Task3()
    {
        /*
            Выводит случайные числа меньше 8, пока не выпадет 7            
        */

        Random random = new Random();
        int current;

        do
        {
            current = random.Next(1, 11);

            if (current >= 8)
            {
                continue;
            }

            Console.WriteLine(current);
        } while (current != 7);

    }
    private static void Task2()
    {
        /*
            Печатает случайные числа пока они больше или равны 3
            Выводит последнее числа
        */
        Random random = new Random();
        int current = random.Next(1, 11);

        while (current >= 3)
        {
            Console.WriteLine(current);
            current = random.Next(1, 11);
        }
        Console.WriteLine($"Last number: {current}");
    }
    private static void Task1()
    {
        /*
            Печатает случайные числа пока не выпадет 7
        */

        Random random = new Random();
        int current;

        do
        {
            current = random.Next(1, 101);
            Console.WriteLine(current);
        } while (current != 7);
    }
}