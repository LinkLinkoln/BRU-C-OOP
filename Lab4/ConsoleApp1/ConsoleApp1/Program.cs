using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Умножение матрицы на число");
                Console.WriteLine("2. Умножение матрицы на другую матрицу");
                Console.WriteLine("3. Сложение матриц");
                Console.WriteLine("4. Выход");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Matr4 m1 = GetMatrix();
                        double scalar = GetScalar();
                        Matr4 result1 = m1 * scalar;
                        Console.WriteLine("Результат умножения:");
                        result1.Print();
                        break;
                    case 2:
                        Matr4 m2 = GetMatrix();
                        Matr4 m3 = GetMatrix();
                        Matr4 result2 = m2 * m3;
                        Console.WriteLine("Результат умножения:");
                        result2.Print();
                        break;
                    case 3:
                        Matr4 m4 = GetMatrix();
                        Matr4 m5 = GetMatrix();
                        Matr4 result3 = m4 + m5;
                        Console.WriteLine("Результат сложения:");
                        Console.WriteLine(result3);
                        result3.Print();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }

        static Vec4 CreateVector()
        {
            Vec4 targetVector = new Vec4(
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())
                );
            return targetVector;
        }

        static Matr4 GetMatrix()
        {
            Console.WriteLine("Введите элементы матрицы (4 строки по 4 числа):");
            Vec4 v1 = CreateVector();
            Vec4 v2 = CreateVector();
            Vec4 v3 = CreateVector();
            Vec4 v4 = CreateVector();
            return new Matr4(v1, v2, v3, v4);
        }

        static double GetScalar()
        {
            Console.WriteLine("Введите число:");
            return double.Parse(Console.ReadLine());
        }
    }
}
