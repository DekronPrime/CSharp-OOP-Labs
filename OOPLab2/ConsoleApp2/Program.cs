using System;
using System.Globalization;

class MyClass
{
    public static void Main(string[] args)
    {
        var cultureInfo = new CultureInfo("en-US");

        double a, b, c;

        Console.Write("Enter value of a: ");
        var userInputA = Console.ReadLine();
        while (!double.TryParse(userInputA, NumberStyles.Float, cultureInfo, out a) || a == 0)
        {
            Console.WriteLine("Wrong value for a. It must be a non-zero number. Please, try again!");
            Console.Write("Enter value of a: ");
            userInputA = Console.ReadLine();
        }

        Console.Write("Enter value of b: ");
        var userInputB = Console.ReadLine();
        while (!double.TryParse(userInputB, NumberStyles.Float, cultureInfo, out b))
        {
            Console.WriteLine("Wrong value for b. Please, try again!");
            Console.Write("Enter value of b: ");
            userInputB = Console.ReadLine();
        }

        Console.Write("Enter value of c: ");
        var userInputC = Console.ReadLine();
        while (!double.TryParse(userInputC, NumberStyles.Float, cultureInfo, out c))
        {
            Console.WriteLine("Wrong value for c. Please, try again!");
            Console.Write("Enter value of c: ");
            userInputC = Console.ReadLine();
        }

        double discriminant = Math.Pow(b, 2) - 4 * a * c;
        Console.WriteLine($"Discriminant: {discriminant}");

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"The equation has two solutions: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"The equation has one solution: x = {x}");
        }
        else
        {
            Console.WriteLine("The equation has no real solutions.");
        }
    }
}
