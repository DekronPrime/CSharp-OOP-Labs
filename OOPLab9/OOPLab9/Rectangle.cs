namespace OOPLab9
{
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }

        public override double GetPerimeter() => 2 * (Width + Height);
    }
}
