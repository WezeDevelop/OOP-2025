using System;

class ComplexMatrix
{
    private Complex[] A;
    private Complex[,] B;
    private int M, N;

    public ComplexMatrix(int m, int n)
    {
        M = m;
        N = n;
        A = new Complex[M];
        B = new Complex[N, M];
    }

    public void FillArray()
    {
        Random rand = new Random();
        for (int i = 0; i < M; i++)
        {
            A[i] = new Complex(rand.Next(1, 10), rand.Next(1, 10));
        }
    }

    public void GenerateMatrix()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                B[i, j] = Complex.Pow(A[j], i + 1);
            }
        }
    }

    public void PrintArray()
    {
        Console.WriteLine("Array A:");
        foreach (var item in A)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public void PrintMatrix()
    {
        Console.WriteLine("Matrix B:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write(B[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int M = 5, N = 3;
        ComplexMatrix matrix = new ComplexMatrix(M, N);
        matrix.FillArray();
        matrix.PrintArray();
        matrix.GenerateMatrix();
        matrix.PrintMatrix();
    }
}

public struct Complex
{
    public double Real { get; }
    public double Imaginary { get; }

    public Complex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static Complex operator +(Complex c1, Complex c2) => new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    public static Complex operator -(Complex c1, Complex c2) => new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    public static Complex operator *(Complex c1, Complex c2) => new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);
    public static Complex operator /(Complex c1, Complex c2)
    {
        double denom = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
        return new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denom, (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denom);
    }

    public double Modulus() => Math.Sqrt(Real * Real + Imaginary * Imaginary);

    public static Complex Pow(Complex c, int power)
    {
        Complex result = new Complex(1, 0);

        for (int i = 0; i < power; i++)
        {
            result *= c;
        }
        return result;
    }

    public override string ToString() => $"({Real} + {Imaginary}i)";
}
