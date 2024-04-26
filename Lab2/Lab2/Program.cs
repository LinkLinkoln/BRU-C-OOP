using Lab2;

public class Porgram
{
    static void Main(string[] args)
    {
        ArrayOperations array1 = new ArrayOperations(10);
        ArrayOperations array2 = new ArrayOperations(15, -10, 10);

        Console.WriteLine("Первый массив:");
        Console.WriteLine(array1.SumPositiveElements());
        Console.WriteLine(array1.ProductBetweenMinMax());
        Console.WriteLine(array1.MaxElement);

        Console.WriteLine("\nВторой массив:");
        Console.WriteLine(array2.SumPositiveElements());
        Console.WriteLine(array2.ProductBetweenMinMax());
        Console.WriteLine(array2.MaxElement);
    }
}