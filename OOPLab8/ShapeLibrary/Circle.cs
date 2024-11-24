namespace ShapeLibrary
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle() : this("Невідоме коло", 0, (0, 0), 0) { }

        public Circle(string name, double area)
            : base(name, area)
        {
            Radius = 0;
        }

        public Circle(string name, double area, (double X, double Y) coords)
            : base(name, area, coords)
        {
            Radius = 0;
        }

        public Circle(string name, double area, double radius)
            : base(name, area)
        {
            Radius = radius;
        }

        public Circle(string name, double area, (double X, double Y) coords, double radius)
            : base(name, area, coords)
        {
            Radius = radius;
        }

        public Circle(Circle other) : base(other)
        {
            Radius = other.Radius;
        }

        public void ChangeRadius(double newRadius)
        {
            Radius = newRadius;
            Area = Math.PI * newRadius * newRadius;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Радіус: {Radius}");
        }
    }
}
