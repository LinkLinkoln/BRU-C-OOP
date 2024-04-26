using System;

public class LinearEquation3
{
    private double a;
    private double b;

    public LinearEquation3(double a, double b)
    {
        if (a == 0)
        {
            throw new ArgumentException("Коэффициент 'a' не может быть равен нулю.");
        }

        this.a = a;
        this.b = b;
    }

    public double GetRoot()
    {
        if (a == 0)
        {
            throw new ArgumentException("Коэффициент 'a' не может быть равен нулю.");
        }

        return -b / a;
    }
}