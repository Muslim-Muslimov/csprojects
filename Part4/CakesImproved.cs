using ConsoleUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movsar_part4
{
    internal class CakesImprovement
    {
            const string PATH = @"CakesPrice.txt";
        internal static void FindCake()
        {
            Console.WriteLine("Введите название торта: ");
            string? selectedName = InputService.GetString();
            string contents = File.ReadAllText(PATH);
            string[] entries = contents.Split("\r\n");

            bool found = false;

            for (int i = 0; i < entries.Length - 1; i++)
            {
                string entry = entries[i].ToLower();

                if (entry.Contains(selectedName.ToLower()))
                {
                    found = true;
                    string[] data = entry.Split(" ");
                    Console.WriteLine($"Название торта: {data[0]}, Цена: {data[1]} руб.");
                }
            }
            if (found == false)
            {
                Console.WriteLine("Нет такого торта");
            }
        }
        internal static void AddCake()
        {
            Console.WriteLine("Введите данные о торте");

            Console.Write("Название торта: ");
            string? name = InputService.GetString();

            Console.WriteLine("Цена торта: ");
            int? price = InputService.GetInt();

            try
            {
                File.AppendAllText(PATH, $"{name} {price}\r\n");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Нет доступа к указанному пути");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Возникла непонятная ошибка");
                return;
            }

            Console.WriteLine("Данные о торте успешно добавлены в файл");
        }
        internal static void Start()
        {

            // Выбор режима
            string[] modes = { "1 - Выбор торта", "2 - Внести в прайс новый торт" };
            int? mode = InputService.GetOption(modes);

            switch (mode)
            {
                case 1:
                    FindCake();
                    Console.ReadKey();
                    Start();
                    break;

                case 2:
                    AddCake();
                    Console.ReadKey();
                    Start();
                    break;
            }
        }
    }
}
