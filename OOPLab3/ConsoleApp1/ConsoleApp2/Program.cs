using System.Text;

class Program
{
    static void Main(String[] args) {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        int n;
        int m;
        Console.Write("Введіть кількість рядків масиву n: ");
        var inputN = Console.ReadLine();
        while (!int.TryParse(inputN, out n) || n < 0)
        {
            Console.WriteLine("Неправильне значення n. Це має бути ціле число. Спробуйте знову!");
            Console.Write("Введіть кількість рядків масиву n: ");
            inputN = Console.ReadLine();
        }

        Console.Write("Введіть кількість стовпців масиву m: ");
        var inputM = Console.ReadLine();
        while (!int.TryParse(inputM, out m) || m < 0)
        {
            Console.WriteLine("Неправильне значення m. Це має бути ціле число. Спробуйте знову!");
            Console.Write("Введіть кількість стовпців масиву m: ");
            inputM = Console.ReadLine();
        }

        var minValue = -110.34;
        var maxValue = 110.35;
        Console.WriteLine("Мінімальне значення діапазону: {0}", minValue);
        Console.WriteLine("Максимальне значення діапазону: {0}", maxValue);

        double[,] arr = new double[n,m];
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++) { 
                var r = random.NextDouble();
                arr[i,j] = Math.Round(r * (maxValue - minValue) + minValue, 2);
            }
        }

        Console.WriteLine("Згенерований масив:");
        displayArray(arr);

        double[] maxRowElements = new double[n];
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            double maxEl = arr[i,0];
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] > maxEl) { 
                    maxEl = arr[i, j];
                }
            }
            maxRowElements[i] = maxEl;
        }

        Console.WriteLine("Найбільші елементи кожного ряду: ");
        for (int i = 0; i < maxRowElements.Length; i++) {
            Console.WriteLine("{0}. {1}",i + 1,maxRowElements[i]);
        }
        var minEl = maxRowElements.Min();
        Console.WriteLine("Найменший з них: {0}", minEl);

        Console.WriteLine("Масив до перестановки елементів в рядах: ");
        displayArray(arr);

        for (int i = 0; i < arr.GetLength(0); i++) {
            double[] tempArr = new double[arr.GetLength(1)];
            for (int j = 0; j < arr.GetLength(1); j++) { 
                tempArr[j] = arr[i,j];
            }
            Array.Reverse(tempArr);
            for (int j = 0; j < arr.GetLength(1); j++) {
                arr[i,j] = tempArr[j];
            }
        }

        Console.WriteLine("Масив після перестановки елементів в рядах: ");
        displayArray(arr);
    }

    static void displayArray(double[,] array) {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write("{0}\t", array[i, j]);
            }
            Console.WriteLine();
        }
    }
}
