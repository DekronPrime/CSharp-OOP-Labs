namespace OOPLab9 { 
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IShape[] shapes = new IShape[3];
            shapes[0] = InitRect();
            shapes[1] = InitCircle();
            shapes[2] = InitTrap();

            Console.WriteLine();
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape);
            }
        }

        static IShape InitRect() {
            Console.WriteLine("\nВведення сторін прямокутника");
            int a;
            Console.Write("Введіть сторону прямокутника A: ");
            var inputA = Console.ReadLine();
            while (!int.TryParse(inputA, out a) || a <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть сторону прямокутника A: ");
                inputA = Console.ReadLine();
            }

            int b;
            Console.Write("Введіть сторону прямокутника B: ");
            var inputB = Console.ReadLine();
            while (!int.TryParse(inputB, out b) || b <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть сторону прямокутника B: ");
                inputB = Console.ReadLine();
            }

            return new Rectangle("Прямокутник", a, b);
        }

        static IShape InitCircle()
        {
            Console.WriteLine("\nВведення радіуса кола");
            int r;
            Console.Write("Введіть радіус кола R: ");
            var inputR = Console.ReadLine();
            while (!int.TryParse(inputR, out r) || r <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть радіус кола R: ");
                inputR = Console.ReadLine();
            }

            return new Circle("Коло", r);
        }

        static IShape InitTrap()
        {
            Console.WriteLine("\nВведення сторін трапеції");
            int a;
            Console.Write("Введіть сторону трапеції A: ");
            var inputA = Console.ReadLine();
            while (!int.TryParse(inputA, out a) || a <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть сторону трапеції A: ");
                inputA = Console.ReadLine();
            }

            int b;
            Console.Write("Введіть сторону трапеції B: ");
            var inputB = Console.ReadLine();
            while (!int.TryParse(inputB, out b) || b <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть сторону трапеції B: ");
                inputB = Console.ReadLine();
            }

            int c;
            Console.Write("Введіть сторону трапеції C: ");
            var inputC = Console.ReadLine();
            while (!int.TryParse(inputC, out c) || c <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть сторону трапеції C: ");
                inputC = Console.ReadLine();
            }

            int d;
            Console.Write("Введіть сторону трапеції D: ");
            var inputD = Console.ReadLine();
            while (!int.TryParse(inputD, out d) || d <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть сторону трапеції D: ");
                inputD = Console.ReadLine();
            }

            return new Trapezium("Трапеція", a, b, c, d);
        }
    }
}