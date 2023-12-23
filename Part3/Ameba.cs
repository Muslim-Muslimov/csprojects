internal static class Ameba
{
    internal static void Start()
    {
        /*
        C4.3. Одноклеточная амеба каждые 3 часа делится на 2 клетки.
         Определить, сколько клеток будет через 3, 6, 9, …, 24 часа,
          если первоначально была одна амеба.

          изначально - 1 амеба
          через 3 часа - 2 амебы
          через 6 часов - 4 амебы
          через 9 часов - 8 амеб
          через 12 часов - 16 амеб

        Алгоритм (от лица программиста)
        1. Создать переменную для хранения количества клеток в организме(kletkiVOrganizme)
        2. Создать переменную для хранения колчиства клеток в организме за каждые 3 часа (kletkiVOrganizmeKajdie3Chasa)
        3. Создать переменну для хранения времен удвоения(vremenaUdvoenie)           
        4. Начать цикл для симулиции времени(time) и продолжать пока (time != 24)
        
        5. Если прошло 3 часа, 
            5.1 Удвоить kletkiVOrganizme
            5.2. Показать kletkiVOrganizme за time
            5.3. Добавить kletkiVOrganizme в массив kletkiVOrganizmeKajdie3Chasa
            5.4  Добавить time в массив vremenaUdvoenie
        
        6. Повторить цикл
        7. Найти индекс 6 внутри vremenaUdvoenie (indexVremeni)
            7.1 Начать цикл для перебора всех элементов массива vremenaUdvoenie
                7.2 Получить значение очередного элемента (momentVremeni)
                7.3 Если (momentVremeni == 6) истина
                    7.3.1 Присвоить (indexVremeni) значение (i).
            7.4 Повторять цикл, пока индекс очередного элемента (i) меньше количества элементов в массиве        

        8. Найти kletki в kletkiVOrganizmeKajdie3Chasa по indexVremeni
        9. Показать kletki
        */

        int kletkiVOrganizme = 1;

        int time = 0;

        int[] kletkiVOrganizmeKajdie3Chasa = new int[8];           //1, 2, 4, 8, 16, 32...
        int[] vremenaUdvoenie = new int[8];                        //0, 3, 6, 9, 12, 15, 18...
        
        // Переменная для хранения текущего индекса элементов массивов.
        int index = 0; 
        
        // Цикл для симуляции времени. 
        while ((time != 24))
        {
            // Добавление одного часа к текущему времени ( 1 итерация = 1 час).  
            time += 1;

            if (time % 3 == 0)
            {
                kletkiVOrganizme = kletkiVOrganizme *   2;
                // 1 = 1 * 2
                Console.WriteLine($"Время : {time}, количесвто амеб: {kletkiVOrganizme}");
                kletkiVOrganizmeKajdie3Chasa[index] = kletkiVOrganizme;
                vremenaUdvoenie[index] = time; 
            }
        }
        
        // Переменная для хранения индекса указанного момента времени 
        int indexVremeni = 0;
        
        // i это индекс (порядок) очередного элемента массива (vremenaUdvoenie)
        for (int i = 0; i < vremenaUdvoenie.Length; i++)
        {
            int momentVremeni =  vremenaUdvoenie[i];
            if (momentVremeni == 6)
            {
                indexVremeni = i;
            }
        }
        int kletki = kletkiVOrganizmeKajdie3Chasa[indexVremeni]; 

        Console.WriteLine($"Количество клеток через 6 часов: {kletki}");


    }
}