namespace OOPLab9
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double GetPerimeter() => 2 * Math.PI * Radius;
    }
}
