using System;

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
    }
}
