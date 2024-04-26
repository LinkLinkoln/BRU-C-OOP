using System;

public class LinearEquation5
{
    private double a;
    private double b;

    public LinearEquation5(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public double GetRoot()
    {
        try
        {
            try
            {
                return -b / a;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ошибка: Деление на ноль!");
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Неожиданная ошибка: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Блок finally выполнен.");
        }
        return a;
    }
}