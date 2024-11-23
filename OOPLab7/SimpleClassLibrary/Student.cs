namespace SimpleClassLibrary
{
    public class Student
    {
        private string fullName;
        private string group;
        private int courseNumber;
        private Result[] results;
        private double monthlyFee;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public int CourseNumber
        {
            get { return courseNumber; }
            set { courseNumber = value > 0 ? value : throw new ArgumentException("Номер курсу має бути позитивним."); }
        }

        public Result[] Results
        {
            get { return results; }
            set { results = value; }
        }

        public double MonthlyFee
        {
            get { return monthlyFee; }
            set { monthlyFee = value >= 0 ? value : throw new ArgumentException("Вартість навчання не може бути від'ємною."); }
        }

        public double YearlyFee => MonthlyFee * 10;

        public double FullPeriodFee => MonthlyFee * 40;

        public Student()
        {
            FullName = string.Empty;
            Group = string.Empty;
            CourseNumber = 1;
            Results = Array.Empty<Result>();
            MonthlyFee = 0;
        }

        public Student(string fullName, string group, int courseNumber, Result[] results)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = courseNumber;
            Results = results;
            MonthlyFee = 0;
        }

        public Student(string fullName, string group, int courseNumber, Result[] results, double monthlyFee)
        {
            FullName = fullName;
            Group = group;
            CourseNumber = courseNumber;
            Results = results;
            MonthlyFee = monthlyFee;
        }

        public Student(Student other)
        {
            FullName = other.FullName;
            Group = other.Group;
            CourseNumber = other.CourseNumber;
            Results = other.Results.Select(r => new Result(r)).ToArray();
            MonthlyFee = other.MonthlyFee;
        }

        public double GetAveragePoint()
        {
            return Results.Average(r => r.Points);
        }

        public string GetWorstSubject()
        {
            return Results.OrderBy(r => r.Points).First().SubjectName;
        }

        public void InputFee()
        {
            Console.WriteLine("\nОберіть одиниці вимірювання для введення вартості навчання:");
            Console.WriteLine("1 - За місяць");
            Console.WriteLine("2 - За рік");
            Console.WriteLine("3 - За весь період навчання");
            Console.Write("Ваш вибір: ");
            string? choice = Console.ReadLine();
            Console.WriteLine();
            double fee;
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть вартість навчання за місяць (грн): ");
                    fee = ReadPositiveDouble();
                    MonthlyFee = fee;
                    break;

                case "2":
                    Console.Write("Введіть вартість навчання за рік (грн): ");
                    fee = ReadPositiveDouble();
                    MonthlyFee = fee / 10;
                    break;

                case "3":
                    Console.Write("Введіть вартість навчання за весь період (грн): ");
                    fee = ReadPositiveDouble();
                    MonthlyFee = fee / 40;
                    break;

                default:
                    Console.WriteLine("Неправильний вибір. Вартість навчання не встановлено.");
                    break;
            }
        }

        private double ReadPositiveDouble()
        {
            double value;
            var input = Console.ReadLine();
            while (!double.TryParse(input, out value) || value < 0)
            {
                Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                input = Console.ReadLine();
            }
            return value;
        }

        public void DisplayFee()
        {
            Console.WriteLine($"Студент: {FullName}");
            Console.WriteLine($"Вартість навчання за місяць: {MonthlyFee:F2} грн");
            Console.WriteLine($"Вартість навчання за рік: {YearlyFee:F2} грн");
            Console.WriteLine($"Вартість навчання за весь період навчання: {FullPeriodFee:F2} грн");
        }

        public override string ToString()
        {
            return $"Студент: {FullName},\nГрупа: {Group},\nКурс: {CourseNumber},\nРезультати: [{string.Join(";\n", Results.Select(r => r.ToString()))}],\nВартість за місяць: {MonthlyFee:F2} грн";
        }
    }
}
