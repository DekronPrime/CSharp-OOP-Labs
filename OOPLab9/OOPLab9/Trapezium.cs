namespace OOPLab9
{
    public class Trapezium : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public Trapezium(string name, double a, double b, double c, double d) : base(name)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override double GetPerimeter() => A + B + C + D;
    }
}
