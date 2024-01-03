internal class Peregruzka
{
    internal static void Start()
    {
        Console.WriteLine(Sum(1, 8, 9));
    }

    private static int Sum(int a, int b)
    {
        Console.WriteLine("1st overload");
        return a + b;
    }

    private static int Sum(int a, int b, int c)
    {
        Console.WriteLine("2nd overload");
        return a + b + c;
    }
}