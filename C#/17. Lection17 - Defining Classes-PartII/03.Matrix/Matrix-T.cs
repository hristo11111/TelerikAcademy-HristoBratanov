using System;

class Matrix_T<T> 
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    private int rows;
    private int colls;

    public int Rows
    {
        get
        {
            return this.rows;
        }
    }

    public int Colls
    {
        get
        {
            return this.colls;
        }
    }

    T[,] elements;

    public Matrix_T(int rows, int colls)
    {
        elements = new T[rows, colls];
        this.rows = elements.GetLength(0);
        this.colls = elements.GetLength(1);
    }

    public Matrix_T()
    {
        elements = new T[rows, colls];
        this.rows = elements.GetLength(0);
        this.colls = elements.GetLength(1);
    }

    public T this[int rows, int colls]
    {
        get
        {
            if (rows < 0 || colls < 0 || rows > this.elements.GetLength(0) || colls > this.elements.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
            return this.elements[rows, colls];
        }

        set
        {
            if (rows < 0 || colls < 0 || rows > this.elements.GetLength(0) || colls > this.elements.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("index out of range");
            }
            this.elements[rows, colls] = value;
        }
    }

    public static Matrix_T<T> operator +(Matrix_T<T> matrix1, Matrix_T<T> matrix2)
    {
        if (matrix1.colls != matrix2.colls || matrix1.rows!= matrix2.rows)
        {
            throw new ArgumentException("matrixes have different dimensions");
        }
        else
        {
            Matrix_T<T> result = new Matrix_T<T>(matrix1.rows, matrix1.colls);
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix2.colls; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] + (dynamic)matrix2[i, j];
                }
            }
            return result;
        }
        
    }

    public static Matrix_T<T> operator -(Matrix_T<T> matrix1, Matrix_T<T> matrix2)
    {
        if (matrix1.colls != matrix2.colls || matrix1.rows != matrix2.rows)
        {
            throw new ArgumentException("matrixes have different dimensions");
        }
        else
        {
            Matrix_T<T> result = new Matrix_T<T>(matrix1.rows, matrix1.colls);
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix2.colls; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] - (dynamic)matrix2[i, j];
                }
            }
            return result;
        }
    }

    public static Matrix_T<T> operator *(Matrix_T<T> matrix1, Matrix_T<T> matrix2)
    {
        if (matrix1.colls != matrix2.colls || matrix1.rows != matrix2.rows)
        {
            throw new ArgumentException("matrixes have different dimensions");
        }
        else
        {
            Matrix_T<T> result = new Matrix_T<T>(matrix1.rows, matrix1.colls);
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix2.colls; j++)
                {
                    result[i, j] = (dynamic)matrix1[i, j] * (dynamic)matrix2[i, j];
                }
            }
            return result;
        }
    }

    public static bool operator true(Matrix_T<T> matrix)
    {
        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.colls; j++)
            {
                if (matrix[i, j].Equals(default(T)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator false(Matrix_T<T> matrix)
    {
        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.colls; j++)
            {
                if (matrix[i, j].Equals(default(T)))
                {
                    return true;
                }
            }
        }
        return false;
    }
        
}
