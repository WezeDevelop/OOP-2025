using System;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введіть рядок: ");
        string input = Console.ReadLine();

        // а) Видалення всіх цифр
        string withoutDigits = new string(input.Where(c => !char.IsDigit(c)).ToArray());

        // б) Подвоєння одинарних пробілів
        string doubledSpaces = withoutDigits.Replace(" ", "  ");

        Console.WriteLine("Результат:");
        Console.WriteLine(doubledSpaces);
    }
}
