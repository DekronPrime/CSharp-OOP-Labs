using System.Globalization;
using System.Text;

class Program 
{
    static void Main(String[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        int n;
        Console.Write("Введіть кількість елементів масиву n: ");
        var inputN = Console.ReadLine();
        while (!int.TryParse(inputN, out n) || n < 0)
        {
            Console.WriteLine("Неправильне значення n. Це має бути ціле число. Спробуйте знову!");
            Console.Write("Введіть кількість елементів масиву n: ");
            inputN = Console.ReadLine();
        }

        var minValue = -14.2;
        var maxValue = 18.3;
        Console.WriteLine("Мінімальне значення діапазону: {0}", minValue);
        Console.WriteLine("Максимальне значення діапазону: {0}", maxValue);

        double[] arr = new double[n];
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            var r = random.NextDouble();
            arr[i] = Math.Round(r * (maxValue - minValue) + minValue, 1);
        }

        Console.Write("Згенерований масив: ");
        displayArray(arr);
        Console.WriteLine();

        var minElemIndex = Array.IndexOf(arr, arr.Min());
        var maxElemIndex = Array.IndexOf(arr, arr.Max());
        Console.WriteLine("Індекс мінімального елемента: {0}", minElemIndex);
        Console.WriteLine("Індекс максимального елемента: {0}", maxElemIndex);

        var startIndex = Math.Min(minElemIndex, maxElemIndex);
        var endIndex = Math.Max(minElemIndex, maxElemIndex);

        int sum = 0;
        for (int i = startIndex + 1; i < endIndex; i++)
        {
            sum += i;
        }
        Console.WriteLine("Сума індексів між мінімальним та максимальним елементами: {0}", sum);

        Console.WriteLine("Масив до заміни елементів: ");
        displayArray(arr);
        Console.WriteLine();

        Array.Reverse(arr, startIndex + 1, endIndex - startIndex - 1);

        Console.WriteLine("Масив після заміни елементів: ");
        displayArray(arr);
    }

    static void displayArray(double[] array) {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0}\t", array[i]);
        }
    }
}