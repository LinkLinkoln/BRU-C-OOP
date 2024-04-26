public class Vec4
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float W { get; set; }

    public Vec4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    // Перегрузка оператора сложения двух векторов
    public static Vec4 operator +(Vec4 v1, Vec4 v2)
    {
        return new Vec4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
    }

    // Перегрузка оператора умножения вектора на число
    public static Vec4 operator *(Vec4 v, float scalar)
    {
        return new Vec4(v.X * scalar, v.Y * scalar, v.Z * scalar, v.W * scalar);
    }
}