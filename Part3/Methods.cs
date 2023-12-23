internal static class Methods
{
    internal static void Recursion(string path)
    {
        string[] directoryNames;
        try
        {
            directoryNames = Directory.GetDirectories(path);
        }
        catch (Exception)
        {
            return;
        }

        foreach (string name in directoryNames)
        {
            Console.WriteLine(name);

            Recursion(name);
        }
    }

    enum DayTime
    {
        Morning,
        Afternoon,
        Evening,
        Night
    }

    internal static void Start()
    {
        DayTime dayTime = DayTime.Morning;

        if (dayTime == DayTime.Morning)
        {
            Console.WriteLine("Доброе утро");
        }
        else
        {
            Console.WriteLine("Привет");
        }


        Console.ReadKey();
    }


}