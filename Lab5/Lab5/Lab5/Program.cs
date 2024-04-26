using System;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinearEquation equation1 = new LinearEquation(2, 3);
            double root = equation1.GetRoot();
            Console.WriteLine(root);

            LinearEquation equation2 = new LinearEquation(2, 3);
            root = equation2.GetRoot();
            Console.WriteLine(root);

            LinearEquation equation3 = new LinearEquation(2, 3);
            root = equation3.GetRoot();
            Console.WriteLine(root);

            LinearEquation equation4 = new LinearEquation(2, 3);
            root = equation4.GetRoot();
            Console.WriteLine(root);

            LinearEquation equation5 = new LinearEquation(2, 3);
            root = equation5.GetRoot();
            Console.WriteLine(root);

            Console.ReadKey();
        }
    }
}
