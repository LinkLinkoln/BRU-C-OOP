using System;

public class LinearEquation
{
    private double a;
    private double b;

    public LinearEquation(double a, double b)
    {
        if (a == 0)
        {
            throw new DivideByZeroException("Деление на ноль!");
        }

        this.a = a;
        this.b = b;
    }

    public double GetRoot()
    {
        try
        {
            return -b / a;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return double.NaN;
        }
        finally
        {
            Console.WriteLine("Блок finally выполнен.");
        }
    }
}