namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();

            studentDictionary.Add(1, new Student("Тарнавський П.В.", "КН-321", 3, 3000));

            studentDictionary.Add(2, new Student("Коваленко О.М.", "КН-221", 2, 2500));

            Console.WriteLine("Поточний список студентів у колекції:");
            PrintDictionary(studentDictionary);

            Console.WriteLine("\nВилучення студента з id = 1:");
            studentDictionary.Remove(1);
            Console.WriteLine("Поточний список студентів:");
            PrintDictionary(studentDictionary);

            Console.WriteLine("\nПеревірка наявності студента з id = 2:");
            if (studentDictionary.ContainsKey(2))
                Console.WriteLine($"Знайдено: {studentDictionary[2].FullName}");
            else
                Console.WriteLine("Студента не знайдено.");

            Console.WriteLine($"\nКількість студентів у колекції: {studentDictionary.Count}");

            Console.WriteLine("\nОчищення колекції студентів...");
            studentDictionary.Clear();
            Console.WriteLine($"Кількість студентів після очищення: {studentDictionary.Count}");
        }

        static void PrintDictionary(Dictionary<int, Student> dictionary)
        {
            foreach (var entry in dictionary)
            {
                Console.WriteLine($"Id: {entry.Key}, {entry.Value.FullName}, Група: {entry.Value.Group}, Курс: {entry.Value.CourseNumber}");
            }
        }

    }
}