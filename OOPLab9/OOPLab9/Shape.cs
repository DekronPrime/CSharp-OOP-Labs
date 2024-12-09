namespace OOPLab9
{
    public abstract class Shape : IShape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double GetPerimeter();

        public override string ToString() => $"Фігура: {Name}, Периметр: {GetPerimeter():F2}";
    }
}
