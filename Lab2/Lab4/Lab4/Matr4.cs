public class Matr4
{
    private Vec4[] rows;

    public Matr4(Vec4 row1, Vec4 row2, Vec4 row3, Vec4 row4)
    {
        rows = new Vec4[4];
        rows[0] = row1;
        rows[1] = row2;
        rows[2] = row3;
        rows[3] = row4;
    }

    // Перегрузка оператора умножения матрицы на число
    public static Matr4 operator *(Matr4 matrix, float scalar)
    {
        Vec4[] newRows = new Vec4[4];
        for (int i = 0; i < 4; i++)
        {
            newRows[i] = matrix.rows[i] * scalar;
        }
        return new Matr4(newRows[0], newRows[1], newRows[2], newRows[3]);
    }

    // Перегрузка оператора умножения матрицы на матрицу
    public static Matr4 operator *(Matr4 matrix1, Matr4 matrix2)
    {
        Vec4[] newRows = new Vec4[4];
        for (int i = 0; i < 4; i++)
        {
            newRows[i] = new Vec4(
                matrix1.rows[i].X * matrix2.rows[0].X + matrix1.rows[i].Y * matrix2.rows[1].X + matrix1.rows[i].Z * matrix2.rows[2].X + matrix1.rows[i].W * matrix2.rows[3].X,
                matrix1.rows[i].X * matrix2.rows[0].Y + matrix1.rows[i].Y * matrix2.rows[1].Y + matrix1.rows[i].Z * matrix2.rows[2].Y + matrix1.rows[i].W * matrix2.rows[3].Y,
                matrix1.rows[i].X * matrix2.rows[0].Z + matrix1.rows[i].Y * matrix2.rows[1].Z + matrix1.rows[i].Z * matrix2.rows[2].Z + matrix1.rows[i].W * matrix2.rows[3].Z,
                matrix1.rows[i].X * matrix2.rows[0].W + matrix1.rows[i].Y * matrix2.rows[1].W + matrix1.rows[i].Z * matrix2.rows[2].W + matrix1.rows[i].W * matrix2.rows[3].W
            );
        }
        return new Matr4(newRows[0], newRows[1], newRows[2], newRows[3]);
    }

    // Перегрузка оператора сложения двух матриц
    public static Matr4 operator +(Matr4 matrix1, Matr4 matrix2)
    {
        Vec4[] newRows = new Vec4[4];
        for (int i = 0; i < 4; i++)
        {
            newRows[i] = matrix1.rows[i] + matrix2.rows[i];
        }
        return new Matr4(newRows[0], newRows[1], newRows[2], newRows[3]);
    }

    // Перегрузка метода ToString() для вывода матрицы в строку
    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < 4; i++)
        {
            result += rows[i].X + "\t" + rows[i].Y + "\t" + rows[i].Z + "\t" + rows[i].W + "\n";
        }
        return result;
    }
}