using System;

namespace project
{
    class OOP
    {
        static void Main()
        {
            Console.Write("Введіть катет A: ");
            double A = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть катет B: ");
            double B = Convert.ToDouble(Console.ReadLine());

            double C = Math.Sqrt(A * A + B * B); // Гіпотенуза

            double angleA1 = Math.Asin(A / C) * (180 / Math.PI); // Кут A1 у градусах
            double angleB1 = Math.Asin(B / C) * (180 / Math.PI); // Кут B1 у градусах

            Console.WriteLine($"Кут A1: {angleA1:F2} градусів");
            Console.WriteLine($"Кут B1: {angleB1:F2} градусів");
        }
    }
}