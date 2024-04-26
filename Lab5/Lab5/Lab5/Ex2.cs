using System;

public class LinearEquation2
{
    private double a;
    private double b;

    public LinearEquation2(double a, double b)
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
            Console.WriteLine("Ошибка: " + ex.GetType().Name + " - " + ex.Message);
            return double.NaN;
        }
        finally
        {
            Console.WriteLine("Блок finally выполнен.");
        }
    }
}