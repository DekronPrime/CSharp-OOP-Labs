namespace ShapeLibrary
{
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("Знаменник не може бути 0.");
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction() : this(0, 1) { }

        public Fraction(Fraction other)
        {
            Numerator = other.Numerator;
            Denominator = other.Denominator;
        }

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator -(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

        public static Fraction operator /(Fraction a, Fraction b)
            => new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);

        public static bool operator >(Fraction a, Fraction b)
            => (double)a > (double)b;

        public static bool operator <(Fraction a, Fraction b)
            => (double)a < (double)b;

        public static bool operator >=(Fraction a, Fraction b)
            => (double)a >= (double)b;

        public static bool operator <=(Fraction a, Fraction b)
            => (double)a <= (double)b;

        public static bool operator ==(Fraction a, Fraction b)
            => a.Numerator * b.Denominator == b.Numerator * a.Denominator;

        public static bool operator !=(Fraction a, Fraction b)
            => !(a == b);

        public static explicit operator double(Fraction fraction)
            => (double)fraction.Numerator / fraction.Denominator;

        public override string ToString()
            => $"{Numerator}/{Denominator}";

        public void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
