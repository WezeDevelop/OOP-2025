using System;
using System.Linq;

abstract class Series
{
    public abstract double GetElement(int j);
    public abstract double GetSum(int n);
}

class Linear : Series
{
    private double a1, d;
    public Linear(double a1, double d)
    {
        this.a1 = a1;
        this.d = d;
    }

    public override double GetElement(int j)
    {
        return a1 + (j - 1) * d;
    }

    public override double GetSum(int n)
    {
        return (n / 2.0) * (2 * a1 + (n - 1) * d);
    }
}

class Exponential : Series
{
    private double a1, r;
    public Exponential(double a1, double r)
    {
        this.a1 = a1;
        this.r = r;
    }

    public override double GetElement(int j)
    {
        return a1 * Math.Pow(r, j - 1);
    }

    public override double GetSum(int n)
    {
        if (r == 1)
            return n * a1;
        return a1 * (1 - Math.Pow(r, n)) / (1 - r);
    }
}

class Program
{
    static void ProcessArray(double[] arr)
    {
        int minIndex = Array.IndexOf(arr, arr.Min());
        Console.WriteLine("Index of minimum element: " + minIndex);

        int firstNeg = Array.FindIndex(arr, x => x < 0);
        int secondNeg = Array.FindIndex(arr, firstNeg + 1, x => x < 0);
        if (firstNeg != -1 && secondNeg != -1)
        {
            double sumBetween = arr.Skip(firstNeg + 1).Take(secondNeg - firstNeg - 1).Sum();
            Console.WriteLine("Sum between first and second negative elements: " + sumBetween);
        }

        var transformedArray = arr.Where(x => Math.Abs(x) <= 1).Concat(arr.Where(x => Math.Abs(x) > 1)).ToArray();
        Console.WriteLine("Transformed array: " + string.Join(", ", transformedArray));
    }

    static void ProcessMatrix(double[,] matrix, int row1, int col1, int row2, int col2, int row3, int col3)
    {
        Console.WriteLine("Sum of two elements: " + (matrix[row1, col1] + matrix[row2, col2]));
        Console.WriteLine("Average of three elements: " + ((matrix[row1, col1] + matrix[row2, col2] + matrix[row3, col3]) / 3.0));
    }

    static void Main()
    {
        Series linear = new Linear(2, 3);
        Console.WriteLine("Linear progression: ");
        Console.WriteLine("5th element: " + linear.GetElement(5));
        Console.WriteLine("Sum of first 5 elements: " + linear.GetSum(5));

        Series exponential = new Exponential(2, 3);
        Console.WriteLine("\nExponential progression: ");
        Console.WriteLine("5th element: " + exponential.GetElement(5));
        Console.WriteLine("Sum of first 5 elements: " + exponential.GetSum(5));

        double[] arr = { 0.5, -1.2, 3.4, 0.9, -2.1, 1.5, -0.8 };
        ProcessArray(arr);

        double[,] matrix = { { 1.1, 2.2, 3.3 }, { 4.4, 5.5, 6.6 }, { 7.7, 8.8, 9.9 } };
        ProcessMatrix(matrix, 0, 1, 1, 2, 2, 0);
    }
}
