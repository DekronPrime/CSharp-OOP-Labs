using System;

class MyClass
{
    public static void Main(string[] args)
    {
        int n, k;

        Console.Write("Введіть значення n (n > 0): ");
        var userInputN = Console.ReadLine();
        while (!int.TryParse(userInputN, out n) || n <= 0)
        {
            Console.WriteLine("Неправильне значення n. Це має бути число, більше за 0. Будь ласка, спробуйте ще раз!");
            Console.Write("Введіть значення n (n > 0): ");
            userInputN = Console.ReadLine();
        }

        Console.Write("Введіть значення k (k > 0): ");
        var userInputK = Console.ReadLine();
        while (!int.TryParse(userInputK, out k) || k <= 0)
        {
            Console.WriteLine("Неправильне значення k. Це має бути число, більше за 0. Будь ласка, спробуйте ще раз!");
            Console.Write("Введіть значення k (k > 0): ");
            userInputK = Console.ReadLine();
        }

        string? choice;
        do
        {
            Console.WriteLine("Оберіть умову для розрахунку:");
            Console.WriteLine("1) Сума: 1^(n/1) + 2^(n/2) + ... + k^(n/k)");
            Console.WriteLine("2) Сума: 1^k + 2^k + ... + n^k");
            Console.WriteLine("3) Сума: 1/n^1 + 2/n^2 + ... + k/n^k");
            Console.WriteLine("0) Вихід");
            Console.Write("Оберіть умову: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Умова: 1^(n/1) + 2^(n/2) + ... + k^(n/k)");
                    double sum1 = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        sum1 += Math.Pow(i, (double)n / i);
                    }
                    Console.WriteLine($"Sum1 = {sum1}\n");
                    break;

                case "2":
                    Console.WriteLine("Умова: 1^k + 2^k + ... + n^k");
                    double sum2 = 0;
                    for (int i = 1; i <= n; i++)
                    {
                        sum2 += Math.Pow(i, k);
                    }
                    Console.WriteLine($"Sum2: {sum2}\n");
                    break;

                case "3":
                    Console.WriteLine("Умова: 1/n^1 + 2/n^2 + ... + k/n^k");
                    double sum3 = 0;
                    for (int i = 1; i <= k; i++)
                    {
                        sum3 += i / Math.Pow(n, i);
                    }
                    Console.WriteLine($"Sum3: {sum3}\n");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Немає такої умови\n");
                    break;
            }
        }
        while (choice != "0");
    }
}
