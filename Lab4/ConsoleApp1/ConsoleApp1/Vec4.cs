using System;
public class Vec4
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public double W { get; private set; }

    public Vec4()
    {
        X = 0.0;
        Y = 0.0;
        Z = 0.0;
        W = 0.0;
    }

    public Vec4(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static Vec4 operator +(Vec4 v1, Vec4 v2)
    {
        return new Vec4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
    }

    public static Vec4 operator -(Vec4 v1, Vec4 v2)
    {
        return new Vec4(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z, v1.W - v2.W);
    }

    public static Vec4 operator *(Vec4 v, double scalar)
    {
        return new Vec4(v.X * scalar, v.Y * scalar, v.Z * scalar, v.W * scalar);
    }

    public static Vec4 operator *(Matr4 m, Vec4 v)
    {
        double x = m.V1.X * v.X + m.V2.X * v.Y + m.V3.X * v.Z + m.V4.X * v.W;
        double y = m.V1.Y * v.X + m.V2.Y * v.Y + m.V3.Y * v.Z + m.V4.Y * v.W;
        double z = m.V1.Z * v.X + m.V2.Z * v.Y + m.V3.Z * v.Z + m.V4.Z * v.W;
        double w = m.V1.W * v.X + m.V2.W * v.Y + m.V3.W * v.Z + m.V4.W * v.W;
        return new Vec4(x, y, z, w);
    }
}
