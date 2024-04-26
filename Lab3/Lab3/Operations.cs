using System;

namespace Lab3
{
    public static class Operations
    {
        static public T EnterInfo<T>(string promt)
        {
            Console.WriteLine(promt);
            string input = Console.ReadLine();
            T item = default;
            try
            {
                item = (T)Convert.ChangeType(input, typeof(T));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при преобразовании ввода: " + ex.Message);
            }
            return item;
        }
    }
}
