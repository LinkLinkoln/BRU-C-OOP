using System;

public class InvalidEquationException : Exception
{
    public InvalidEquationException(string message) : base(message)
    {
    }
}

public class LinearEquation4
{
    private double a;
    private double b;

    public LinearEquation4(double a, double b)
    {
        if (a == 0)
        {
            throw new InvalidEquationException("Коэффициент 'a' не может быть равен нулю.");
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
        catch (InvalidEquationException ex)
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