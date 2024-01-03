/*
    Упражнение

    Напишите консольную программу, в которую пользователь вводит с клавиатуры два числа. 
    А программа сранивает два введенных числа и выводит на консоль результат сравнения 
    (два числа равны, первое число больше второго или первое число меньше второго).

    Алгоритм

    1. Получи от пользователя первое число и положи его в коробку подписав её chisloA
    2. Получи от пользователя первое число и положи его в коробку подписав её chisloB
    3. Узнай больше ли число из коробочки chisloA, чем число из коробочки chisloB
    4. Если результат сравнения (chisloA больше ли chisloB) ИСТИНО, 
      тогда скажи что число из коробочки chisloA больше чем число из коробочки chisloB
    5. Если результат сравнения (chisloA больше ли chisloB) ЛОЖЬ, 
      тогда узнай результат сравнения (chisloA равно ли числу chisloB)
    6. Если результат сравнения (chisloA равно ли числу chisloB) ИСТИНО, 
      тогда скажи что chisloA равно chisloB
    7. Если результат сравнения (chisloA равно ли числу chisloB) ЛОЖЬ, 
      тогда узнай что результат сравнения (chisloA меньше ли chisloB) 
    8. Если результат сравнения (chisloA меньше ли chisloB) ИСТИНА,
      тогда скажи что число chisloA меньше chisloB
*/
internal static class SravnenieDvuhChisel
{
    internal static void Start()
    {
        int chisloA = Convert.ToInt32(Console.ReadLine());
        int chisloB = Convert.ToInt32(Console.ReadLine());

        if (chisloA > chisloB)
        {
            Console.WriteLine($"Число А {chisloA} больше, чем Число Б {chisloB}");
        }
        else if (chisloA == chisloB)
        {
            Console.WriteLine($"Число А {chisloA} равно, Число Б {chisloB}");
        }
        else if (chisloA < chisloB)
        {
            Console.WriteLine($"Число А {chisloA} меньше, чем Число Б {chisloB}");
        }
    }
}