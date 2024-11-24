namespace ShapeLibrary
{
    public class Shape
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public (double X, double Y) Coords { get; set; }

        public Shape() : this("Невідома фігура", 0, (0, 0)) { }

        public Shape(string name, double area)
        {
            Name = name;
            Area = area;
            Coords = (0, 0);
        }
        public Shape(string name, double area, (double X, double Y) coords)
        {
            Name = name;
            Area = area;
            Coords = coords;
        }

        public Shape(Shape other)
        {
            Name = other.Name;
            Area = other.Area;
            Coords = other.Coords;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Фігура: {Name}, Площа: {Area}, Координати точки відліку: ({Coords.X}, {Coords.Y})");
        }
    }
}
