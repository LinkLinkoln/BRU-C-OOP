using System;
public class Matr4
{
    public Vec4 V1 { get; private set; }
    public Vec4 V2 { get; private set; }
    public Vec4 V3 { get; private set; }
    public Vec4 V4 { get; private set; }

    public Matr4()
    {
        V1 = new Vec4();
        V2 = new Vec4();
        V3 = new Vec4();
        V4 = new Vec4();
    }

    public Matr4(Vec4 v1, Vec4 v2, Vec4 v3, Vec4 v4)
    {
        V1 = v1;
        V2 = v2;
        V3 = v3;
        V4 = v4;
    }

    public static Matr4 operator *(Matr4 matrix, double scalar)
    {
        Vec4 v1 = matrix.V1 * scalar;
        Vec4 v2 = matrix.V2 * scalar;
        Vec4 v3 = matrix.V3 * scalar;
        Vec4 v4 = matrix.V4 * scalar;
        return new Matr4(v1, v2, v3, v4);
    }

    public static Matr4 operator +(Matr4 matrix1, Matr4 matrix2)
    {
        Vec4 v1 = matrix1.V1 + matrix2.V1;
        Vec4 v2 = matrix1.V2 + matrix2.V2;
        Vec4 v3 = matrix1.V3 + matrix2.V3;
        Vec4 v4 = matrix1.V4 + matrix2.V4;
        return new Matr4(v1, v2, v3, v4);
    }

    public static Matr4 operator *(Matr4 matrix1, Matr4 matrix2)
    {
        Vec4 v1 = matrix1 * matrix2.V1;
        Vec4 v2 = matrix1 * matrix2.V2;
        Vec4 v3 = matrix1 * matrix2.V3;
        Vec4 v4 = matrix1 * matrix2.V4;
        return new Matr4(v1, v2, v3, v4);
    }

    public void Print()
    {
        Console.WriteLine("Matrix:");
        Console.WriteLine($"{V1.X} {V1.Y} {V1.Z} {V1.W}");
        Console.WriteLine($"{V2.X} {V2.Y} {V2.Z} {V2.W}");
        Console.WriteLine($"{V3.X} {V3.Y} {V3.Z} {V3.W}");
        Console.WriteLine($"{V4.X} {V4.Y} {V4.Z} {V4.W}");
    }
}