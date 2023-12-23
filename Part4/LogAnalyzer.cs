internal class LogAnalyzer
{
    internal static void Start()
    {
        string[] logs = {
                         "2023-11-11   08:30:00   INFO Application started successfully",
                         "2023-11-12   08:45:23   WARNING Low memory warning detected",
                         "2023-11-12   09:15:45   ERROR Failed to connect to database",
                         "2023-11-12   09:45:10   INFO User 'admin' logged in",
                         "2023-11-12   10:00:00   ERROR Unexpected exception occurred"
                        };

        foreach (string log in logs)
        {
            string date;
            string time;
            string level;
            string message;

            // Дата
            int dateStartIndex = 0;
            int dateEndIndex = log.IndexOf(" ");
            date = log.Substring(dateStartIndex, dateEndIndex);

            // Смещаем отступ к концу, сначала присваиваем длину Даты, 
            // и увеличиваем пока пробелы не кончатся
            int offset = dateEndIndex;
            while (log.Substring(offset, 1) == " ")
            {
                offset++;
            }

            // Время
            int timeStartIndex = offset;
            int timeEndIndex = log.IndexOf(" ", offset);
            time = log.Substring(timeStartIndex, timeEndIndex - timeStartIndex);

            // Смещаем отступ к концу, сначала присваиваем длину Даты, 
            // и увеличиваем пока пробелы не кончатся
            offset = timeEndIndex;
            while (log.Substring(offset, 1) == " ")
            {
                offset++;
            }

            // Повторяем те же операции для Уровня            
            int levelStartIndex = offset;
            int levelEndIndex = log.IndexOf(" ", offset);
            level = log.Substring(levelStartIndex, levelEndIndex - levelStartIndex);

            // Смещаем отступ к концу, сначала присваиваем длину Даты, 
            // и увеличиваем пока пробелы не кончатся
            offset = levelEndIndex;
            while (log.Substring(offset, 1) == " ")
            {
                offset++;
            }

            // Повторяем те же операции для Сообщения            
            int messageStartIndex = offset;
            message = log.Substring(messageStartIndex);

            Console.WriteLine($"Дата: {date}, Время: {time}, Уровень: {(level + ",").PadRight(8)} Сообщение: {message}.");
        }
    }
}