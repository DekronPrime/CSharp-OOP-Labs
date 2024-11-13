using OOPLab4;
using System.Text;

class Program
{
    public static Angle[] InitializeAngles(int n)
    {
        Angle[] angles = new Angle[n];
        for (int i = 0; i < n; i++)
        {
            int degrees;
            int minutes;

            Console.Write("Введіть градус {0}: ", i + 1);
            var inputDegrees = Console.ReadLine();

            while (!int.TryParse(inputDegrees, out degrees))
            {
                Console.WriteLine("Неправильне значення для градуса! Введіть ціле число");
                Console.Write("Введіть градус {0}: ", i + 1);
                inputDegrees = Console.ReadLine();
            }

            Console.Write("Введіть мінути {0}: ", i + 1);
            var inputMinutes = Console.ReadLine();

            while (!int.TryParse(inputMinutes, out minutes))
            {
                Console.WriteLine("Неправильне значення для мінут! Введіть ціле число");
                Console.Write("Введіть мінути {0}: ", i + 1);
                inputMinutes = Console.ReadLine();
            }

            angles[i] = new Angle(degrees, minutes);
        }
        return angles;
    }

    public static void DisplayAngle(Angle angle)
    {
        Console.WriteLine(angle);
    }

    public static void SortAngles(Angle[] angles)
    {
        Array.Sort(angles, (a, b) =>
        {
            int degreeComparison = a.Degrees.CompareTo(b.Degrees);
            if (degreeComparison == 0)
            {
                int minutesComparison = a.Minutes.CompareTo(b.Minutes);
                return minutesComparison;
            }
            return degreeComparison;
        });
    }

    public static void ModifyAngle(ref Angle angle, int newDegrees, int newMinutes)
    {
        angle = new Angle(newDegrees, newMinutes);
    }

    public static void FindMinMax(Angle[] angles, out Angle min, out Angle max)
    {
        min = angles[0];
        max = angles[0];

        foreach (var angle in angles)
        {
            if (angle.Degrees < min.Degrees || (angle.Degrees == min.Degrees && angle.Minutes < min.Minutes))
            {
                min = angle;
            }
            if (angle.Degrees > max.Degrees || (angle.Degrees == max.Degrees && angle.Minutes > max.Minutes))
            {
                max = angle;
            }
        }
    }

    static void Main(String[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        int n;
        Console.Write("Введіть кількість елементів масиву: ");
        var inputN = Console.ReadLine();

        while (!int.TryParse(inputN, out n))
        {
            Console.WriteLine("Неправильне значення для n! Введіть ціле число більше 0");
            Console.Write("Введіть кількість елементів масиву: ");
            inputN = Console.ReadLine();
        }

        Angle[] angles = InitializeAngles(n);

        Console.WriteLine("\nМасив структур: ");
        for (int i = 0; i < angles.Length; i++) 
        {
            Console.Write("{0}) ", i + 1);
            DisplayAngle(angles[i]);
        }

        FindMinMax(angles, out Angle min, out Angle max);
        Console.WriteLine("\nМінімальний елемент: {0}", min);
        Console.WriteLine("Максимальний елемент: {0}", max);

        SortAngles(angles);
        Console.WriteLine("\nВідсортований масив:");
        for (int i = 0; i < angles.Length; i++)
        {
            Console.Write("{0}) ", i + 1);
            DisplayAngle(angles[i]);
        }

        Console.WriteLine("\nВведіть нові значення для першого кута (градуси і мінути):");
        int newDegrees;
        int newMinutes;

        Console.Write("Введіть новий градус: ");
        var inputNewDegree = Console.ReadLine();

        while (!int.TryParse(inputNewDegree, out newDegrees))
        {
            Console.WriteLine("Неправильне значення для нового градуса! Введіть ціле число більше 0");
            Console.Write("Введіть новий градус: ");
            inputNewDegree = Console.ReadLine();
        }

        Console.Write("Введіть нові мінути: ");
        var inputNewMinutes = Console.ReadLine();

        while (!int.TryParse(inputNewMinutes, out newMinutes))
        {
            Console.WriteLine("Неправильне значення для нових мінут! Введіть ціле число більше 0");
            Console.Write("Введіть нові мінути: ");
            inputNewMinutes = Console.ReadLine();
        }

        ModifyAngle(ref angles[0], newDegrees, newMinutes);
        Console.WriteLine("\nМасив структур після модифікації: ");
        for (int i = 0; i < angles.Length; i++)
        {
            Console.Write("{0}) ", i + 1);
            DisplayAngle(angles[i]);
        }

        Console.WriteLine("\nДемонстрація методів Add та Subtract:");
        if (angles.Length > 1)
        {
            Console.WriteLine("1) + 2):");
            angles[0].Add(angles[1]);
            DisplayAngle(angles[0]);

            Console.WriteLine("1) - 2):");
            angles[0].Subtract(angles[1]);
            DisplayAngle(angles[0]);
        }
    }
}