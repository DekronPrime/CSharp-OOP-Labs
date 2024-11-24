namespace ShapeLibrary
{
    public class Triangle : Shape
    {
        public string Type { get; set; }

        public Triangle() : this("Невідомий трикутник", 0, (0, 0), "Невідомий тип") { }

        public Triangle(string name, double area)
            : base(name, area)
        {
            Type = "Невідомий тип";
        }

        public Triangle(string name, double area, (double X, double Y) coords)
            : base(name, area, coords)
        {
            Type = "Невідомий тип";
        }

        public Triangle(string name, double area, string type)
            : base(name, area)
        {
            Type = type;
        }

        public Triangle(string name, double area, (double X, double Y) coords, string type)
            : base(name, area, coords)
        {
            Type = type;
        }

        public Triangle(Triangle other) : base(other)
        {
            Type = other.Type;
        }

        public void ChangeType(string newType)
        {
            Type = newType;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Тип: {Type}");
        }
    }
}
