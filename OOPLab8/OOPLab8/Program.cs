using System;
using ShapeLibrary;

namespace OOPLab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string? choice;
            do
            {
                Console.WriteLine("\n1 - Робота з трикутниками");
                Console.WriteLine("2 - Робота з колами");
                Console.WriteLine("3 - Робота з дробами");
                Console.WriteLine("0 - Вихід");
                Console.Write("Оберіть умову: ");
                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\t1 - Робота з трикутниками");

                        WorkWithTriangles();

                        break;

                    case "2":
                        Console.WriteLine("\t2 - Робота з колами");
                        
                        WorkWithCircles();

                        break;

                    case "3":
                        Console.WriteLine("\t3 - Робота з дробами");

                        WorkWithFractions();

                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Такого варіанту не передбачено\n");
                        break;
                }
            } while (choice != "0");
        }

        static Shape[] CreateTriangles(int count) {
            Shape[] triangles = new Shape[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введіть координати точки відліку.");

                double coordX;
                Console.Write($"(T-{i + 1}) Введіть x: ");
                var inputCoordX = Console.ReadLine();
                while (!double.TryParse(inputCoordX, out coordX))
                {
                    Console.WriteLine("Неправильне значення. Спробуйте знову!");
                    Console.Write($"(T-{i + 1}) Введіть x: ");
                    inputCoordX = Console.ReadLine();
                }

                double coordY;
                Console.Write($"(T-{i + 1}) Введіть y: ");
                var inputCoordY = Console.ReadLine();
                while (!double.TryParse(inputCoordY, out coordY))
                {
                    Console.WriteLine("Неправильне значення. Спробуйте знову!");
                    Console.Write($"(T-{i + 1}) Введіть y: ");
                    inputCoordY = Console.ReadLine();
                }

                double area;
                Console.Write($"(T-{i + 1}) Введіть площу трикутника: ");
                var inputArea = Console.ReadLine();
                while (!double.TryParse(inputArea, out area) || area <= 0)
                {
                    Console.WriteLine("Неправильне значення. Це має бути число > 0. Спробуйте знову!");
                    Console.Write($"(T-{i + 1}) Введіть площу трикутника: ");
                    inputArea = Console.ReadLine();
                }

                string? type = "Невідомий";
                string inputType;
                do
                {
                    Console.WriteLine($"(T-{i + 1}) Оберіть тип трикутника: ");
                    Console.WriteLine("1 - Рівносторонній");
                    Console.WriteLine("2 - Рівнобедрений");
                    Console.WriteLine("3 - Прямокутний");
                    Console.Write("Оберіть тип: ");
                    inputType = Console.ReadLine() ?? "";
                    switch (inputType)
                    {
                        case "1":
                            type = "Рівносторонній";
                            break;

                        case "2":
                            type = "Рівнобедрений";
                            break;

                        case "3":
                            type = "Прямокутний";
                            break;

                        default:
                            Console.WriteLine("Такого варіанту не передбачено\n");
                            break;
                    }
                }
                while (type == null);
                triangles[i] = new Triangle($"Трикутник-{i + 1}", area, (coordX, coordY), type);
            }
            return triangles;
        }

        static void WorkWithTriangles()
        {
            Console.Write("Введіть кількість трикутників: ");
            int trianglesCount;
            var inputTrianglesCount = Console.ReadLine();
            while (!int.TryParse(inputTrianglesCount, out trianglesCount) || trianglesCount <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть кількість трикутників: ");
                inputTrianglesCount = Console.ReadLine();
            }

            var triangles = CreateTriangles(trianglesCount);
            foreach (var triangle in triangles)
            {
                triangle.ShowInfo();
                Console.WriteLine();
            }
        }

        static Shape[] CreateCircles(int count)
        {
            Shape[] circles = new Shape[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введіть координати точки відліку.");

                double coordX;
                Console.Write($"(С-{i + 1}) Введіть x: ");
                var inputCoordX = Console.ReadLine();
                while (!double.TryParse(inputCoordX, out coordX))
                {
                    Console.WriteLine("Неправильне значення. Спробуйте знову!");
                    Console.Write($"(С-{i + 1}) Введіть x: ");
                    inputCoordX = Console.ReadLine();
                }

                double coordY;
                Console.Write($"(С-{i + 1}) Введіть y: ");
                var inputCoordY = Console.ReadLine();
                while (!double.TryParse(inputCoordY, out coordY))
                {
                    Console.WriteLine("Неправильне значення. Спробуйте знову!");
                    Console.Write($"(С-{i + 1}) Введіть y: ");
                    inputCoordY = Console.ReadLine();
                }

                double area;
                Console.Write($"(С-{i + 1}) Введіть площу кола: ");
                var inputArea = Console.ReadLine();
                while (!double.TryParse(inputArea, out area) || area <= 0)
                {
                    Console.WriteLine("Неправильне значення. Це має бути число > 0. Спробуйте знову!");
                    Console.Write($"(С-{i + 1}) Введіть площу кола: ");
                    inputArea = Console.ReadLine();
                }

                int radius;
                Console.Write($"(С-{i + 1}) Введіть радіус кола: ");
                var inputRadius = Console.ReadLine();
                while (!int.TryParse(inputRadius, out radius) || radius <= 0)
                {
                    Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                    Console.Write($"(С-{i + 1}) Введіть радіус кола: ");
                    inputRadius = Console.ReadLine();
                }

                circles[i] = new Circle($"Коло-{i + 1}", area, (coordX, coordY), radius);
            }
            return circles;
        }

        static void WorkWithCircles()
        {
            Console.Write("Введіть кількість кіл: ");
            int circlesCount;
            var inputCirclesCount = Console.ReadLine();
            while (!int.TryParse(inputCirclesCount, out circlesCount) || circlesCount <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть кількість кіл: ");
                inputCirclesCount = Console.ReadLine();
            }

            var circles = CreateCircles(circlesCount);
            foreach (var circle in circles)
            {
                circle.ShowInfo();
                Console.WriteLine();
            }
        }

        static void WorkWithFractions()
        {
            //int fractionsCount;
            //Console.Write("Введіть кількість дробів: ");
            //var inputFractionsCount = Console.ReadLine();
            //while (!int.TryParse(inputFractionsCount, out fractionsCount) || fractionsCount <= 0)
            //{
            //    Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
            //    Console.Write("Введіть кількість дробів: ");
            //    inputFractionsCount = Console.ReadLine();
            //}

            int fractionsCount = 2;

            var fractions = CreateFractions(fractionsCount);

            var a = fractions[0];
            var b = fractions[1];

            Console.WriteLine($"Дріб A: {a}");
            Console.WriteLine($"Дріб B: {b}");

            Console.WriteLine("\nПорівняння дробів");
            Console.WriteLine($"A + B = {a + b}");
            Console.WriteLine($"A - B = {a - b}");
            Console.WriteLine($"A * B = {a * b}");
            Console.WriteLine($"A / B = {a / b}");
            Console.WriteLine($"A > B: {a > b}");
            Console.WriteLine($"A == B: {a == b}");

            Console.WriteLine("\nПеретворення в десяткові дроби");
            Console.WriteLine($"Дріб А: {a} = {((double)a)}");
            Console.WriteLine($"Дріб B: {b} = {((double)b)}");

            a.Simplify();
            b.Simplify();
            Console.WriteLine("\nСпрощення дробів");
            Console.WriteLine($"Спрощений дріб A: {a}");
            Console.WriteLine($"Спрощений дріб B: {b}");
        }

        static Fraction[] CreateFractions(int count)
        {
            var fractions = new Fraction[count];
            for (int i = 0; i < 2; i++)
            {
                int numerator;
                Console.Write($"\n(Д-{i + 1}) Введіть чисельник: ");
                var inputNumerator = Console.ReadLine();
                while (!int.TryParse(inputNumerator, out numerator))
                {
                    Console.WriteLine("Неправильне значення. Спробуйте знову!");
                    Console.Write($"(Д-{i + 1}) Введіть чисельник: ");
                    inputNumerator = Console.ReadLine();
                }

                int denominator;
                Console.Write($"(Д-{i + 1}) Введіть знаменник: ");
                var inputDenominator = Console.ReadLine();
                while (!int.TryParse(inputDenominator, out denominator))
                {
                    Console.WriteLine("Неправильне значення. Спробуйте знову!");
                    Console.Write($"(Д-{i + 1}) Введіть знаменник: ");
                    inputDenominator = Console.ReadLine();
                }

                fractions[i] = new Fraction(numerator, denominator);
            }
            return fractions;
        }
    }
}