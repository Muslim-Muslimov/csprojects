internal class Cakes
{
    internal static void Start()
    {
        string[] cakes = { "Тортик", "Тортище", "Торт95", "Наполеон" };
        int[] cakePrices = { 1507, 3600, 200, 1230 };

        if (cakes.Length != cakePrices.Length)
        {
            Console.WriteLine("Количество элементов цен и тортов не совпадает!");
            return;
        }

        Console.Write("Муьлха торт еза хьуна?: ");

        string otvetpolzovatelya = Console.ReadLine();

        // 1. Создает переменную i и присваивает значение 0 (ТОЛЬКО ОДИН РАЗ ЗА ВЫПОЛНЕНИЕ ЦИКЛА)
        // 2. Выполнение сравнения условия
        // 3. Выполнение тела цикла
        // 4. Выполнение i = i + 1 (i++)
        // 5. Выполнение сравнения условия
        int count = cakes.Length;

        for (int i = 0; i < count; i++)
        {
            if (cakes[i].ToUpper() == otvetpolzovatelya.ToUpper()){
                Console.WriteLine($"{cakes[i]}ах {cakePrices[i]} сом доьху");
            }
        }

    }
}
