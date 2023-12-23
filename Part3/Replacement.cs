//Даны переменные "a" = 2 и "b" = 4. Надо сделать так, чтобы "b" = "a", а "a" = "b"
/*
 
 
*/
internal static class Replacement
{
    internal static void Start()
    {
        int a = 2;
        int b = 4;
        int c;
        c = a; a = b; b = c;
        Console.WriteLine($"a={a}, b={b}");
    }

}