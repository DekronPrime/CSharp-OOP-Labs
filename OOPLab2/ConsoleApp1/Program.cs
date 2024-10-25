using System.Globalization;

class MyClass
{
    public static void Main(string[] args)
    {
        /*CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");*/

        var cultureInfo = new CultureInfo("en-US");
        
        double x;
        double y;
        double z;

        Console.Write("Enter x number: ");
        var userInputX = Console.ReadLine();
        
        while (!double.TryParse(userInputX, NumberStyles.Float, cultureInfo, out x)) {
            Console.WriteLine("Wrong value x. Please, try again!");
            Console.Write("Enter x number: ");
            userInputX = Console.ReadLine();
        }
        
        Console.Write("Enter y number: ");
        var userInputY = Console.ReadLine();
        
        while (!double.TryParse(userInputY, NumberStyles.Float, cultureInfo, out y)) {
            Console.WriteLine("Wrong value y. Please, try again!");
            Console.Write("Enter y number: ");
            userInputY = Console.ReadLine();
        }
        
        Console.Write("Enter z number: ");
        var userInputZ = Console.ReadLine();
        
        while (!double.TryParse(userInputZ, NumberStyles.Float, cultureInfo, out z)) {
            Console.WriteLine("Wrong value z. Please, try again!");
            Console.Write("Enter z number: ");
            userInputZ = Console.ReadLine();
        }

        var numerator = (y - x) * Math.Cos(y) - (Math.Log10(z) / (x - y));
        var denominator = 1 + Math.Pow(x - z, 2);
        var s = numerator / denominator;
        
        Console.WriteLine("You wrote {0} | {1} | {2}", x, y, z);

        Console.WriteLine("S = {0}", Math.Round(s, 3));
    }
}