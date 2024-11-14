using OOPLab5;
using System.Text;
using System.Text.Json;

public class Program
{
    private const string FileName = "subjects.json";

    public static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        //List<Subject> subjects = InitializeList();
        //WriteToFile(subjects);

        string? choice;
        do
        {
            Console.WriteLine("1 - Прочитати файл");
            Console.WriteLine("2 - Дописати в файл");
            Console.WriteLine("3 - Пошук по назві дисципліни");
            Console.WriteLine("4 - Пошук по прізвищу викладача");
            Console.WriteLine("5 - Пошук по наявності курсової роботи");
            Console.WriteLine("6 - Пошук по номеру семестру");
            Console.WriteLine("0 - Вихід");
            Console.Write("Оберіть умову: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\t1 - Прочитати файл");
                    DisplaySubjects(ReadFromFile());
                    break;
                case "2":
                    Console.WriteLine("\t2 - Дописати в файл");
                    Console.WriteLine("Введіть нову дисципліну: ");
                    var newSubject = InputSubject();
                    AppendToFile(newSubject);
                    Console.WriteLine("Файл дописано");
                    break;
                case "3":
                    Console.WriteLine("\t3 - Пошук по назві дисципліни");
                    Console.Write("Введіть назву дисципліни: ");
                    string? subjectName = Console.ReadLine();
                    var filteredByNameSubjects = FindBySubjectName(ReadFromFile(), subjectName);
                    Console.WriteLine("За назвою дисципліни знайдено записів: " + filteredByNameSubjects.Count);
                    DisplaySubjects(filteredByNameSubjects);
                    break;
                case "4":
                    Console.WriteLine("\t4 - Пошук по прізвищу викладача");
                    Console.Write("Введіть прізвище викладача: ");
                    string? lecturer = Console.ReadLine();
                    var filteredByLecturerSubjects = FindByLecturer(ReadFromFile(), lecturer);
                    Console.WriteLine("За прізвищем викладача знайдено записів: " + filteredByLecturerSubjects.Count);
                    DisplaySubjects(filteredByLecturerSubjects);
                    break;
                case "5":
                    Console.WriteLine("\t5 - Пошук по наявності курсової роботи");
                    bool hasCourseWork = false;
                    Console.Write("Чи є курсова робота? (так (1), ні (0): ");
                    var inputHasCourseWork = Console.ReadLine();
                    do
                    {
                        if (inputHasCourseWork == "1")
                        {
                            hasCourseWork = true;
                        }
                        else if (inputHasCourseWork != "0")
                        {
                            Console.WriteLine("Такого варіанту не передбачено");
                            Console.Write("Чи є курсова робота? (так (1), ні (0)): ");
                            inputHasCourseWork = Console.ReadLine();
                        }
                    }
                    while (inputHasCourseWork != "1" && inputHasCourseWork != "0");
                    var filteredByCourseWorkSubjects = FindByCourseWork(ReadFromFile(), hasCourseWork);
                    Console.WriteLine("За наявністю курсової роботи знайдено записів: " + filteredByCourseWorkSubjects.Count);
                    DisplaySubjects(filteredByCourseWorkSubjects);
                    break;
                case "6":
                    Console.WriteLine("\t6 - Пошук по номеру семестру");
                    Console.Write("Введіть номер семестру: ");
                    int semester;
                    var inputSemester = Console.ReadLine();
                    while (!int.TryParse(inputSemester, out semester) || semester <= 0)
                    {
                        Console.WriteLine("Неправильне значення n. Це має бути ціле число > 0. Спробуйте знову!");
                        Console.Write("Введіть номер семестру: ");
                        inputSemester = Console.ReadLine();
                    }
                    var filteredBySemesterSubjects = FindBySemester(ReadFromFile(), semester);
                    Console.WriteLine("За номером семестру знайдено записів: " + filteredBySemesterSubjects.Count);
                    DisplaySubjects(filteredBySemesterSubjects);
                    break;
                case "0":
                    return;

                default:
                    Console.WriteLine("Немає такої умови\n");
                    break;
            }
        } while (choice != "0");
    }

    public static List<Subject> InitializeList()
    {
        List<Subject> subjects = new();
        int n;
        Console.Write("Введіть кількість дисциплін для заповнення n: ");
        var inputN = Console.ReadLine();
        while (!int.TryParse(inputN, out n) || n <= 0)
        {
            Console.WriteLine("Неправильне значення n. Це має бути ціле число > 0. Спробуйте знову!");
            Console.Write("Введіть кількість дисциплін для заповнення n: ");
            inputN = Console.ReadLine();
        }

        Console.WriteLine("Введіть дані дисциплін: ");
        for (int i = 0; i < n; i++)
            subjects.Add(InputSubject());
        return subjects;
    }

    public static Subject InputSubject()
    {
        Console.Write("Назва дисципліни: ");
        string? name = Console.ReadLine();
        Console.Write("П.І.П. викладача: ");
        string? lecturer = Console.ReadLine();
        Console.Write("Назва групи: ");
        string? groupName = Console.ReadLine();

        int studentsCount;
        Console.Write("Кількість студентів у групі: ");
        var inputStudentsCount = Console.ReadLine();
        while (!int.TryParse(inputStudentsCount, out studentsCount) || studentsCount <= 0)
        {
            Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
            Console.Write("Кількість студентів у групі: ");
            inputStudentsCount = Console.ReadLine();
        }

        FinalControlType finalControlType = FinalControlType.None;
        Console.Write("Тип підсумкового контролю (Екзамен (1), Тест (2), Немає (0 - За замовчуванням)): ");
        var inputFinalControl = Console.ReadLine();
        do
        {
            switch (inputFinalControl)
            {
                case "1":
                    finalControlType = FinalControlType.Exam; break;
                case "2":
                    finalControlType = FinalControlType.Test; break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Такого варіанту не передбачено");
                    Console.Write("Тип підсумкового контролю (Екзамен (1), Тест (2), Немає (0 - За замовчуванням)): ");
                    inputFinalControl = Console.ReadLine();
                    break;
            }
        } while (inputFinalControl != "1" && inputFinalControl != "2" && inputFinalControl != "0");

        bool hasCourseWork = false;
        Console.Write("Чи є курсова робота? (так (1), ні (0 - За замовчуванням)): ");
        var inputHasCourseWork = Console.ReadLine();
        do
        {
            if (inputHasCourseWork == "1")
            {
                hasCourseWork = true;
            }
            else if (inputHasCourseWork != "0") {
                Console.WriteLine("Такого варіанту не передбачено");
                Console.Write("Чи є курсова робота? (так (1), ні (0 - За замовчуванням)): ");
                inputHasCourseWork = Console.ReadLine();
            }
        }
        while (inputHasCourseWork != "1" && inputHasCourseWork != "0");

        Console.Write("Назва спеціальності: ");
        string? specialty = Console.ReadLine();

        int semester;
        Console.Write("Номер семестру: ");
        var inputSemester = Console.ReadLine();
        while (!int.TryParse(inputSemester, out semester) || semester <= 0)
        {
            Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
            Console.Write("Номер семестру: ");
            inputSemester = Console.ReadLine();
        }

        return new Subject
        {
            Name = name,
            Lecturer = lecturer,
            GroupName = groupName,
            StudentsCount = studentsCount,
            FinalControl = finalControlType,
            HasCourseWork = hasCourseWork,
            Specialty = specialty,
            Semester = semester
        };
    }

    public static void WriteToFile(List<Subject> subjects)
    {
        string jsonString = JsonSerializer.Serialize(subjects);
        File.WriteAllText(FileName, jsonString);
    }

    public static List<Subject>? ReadFromFile()
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine("Файл не знайдено.");
            return null;
        }

        string jsonString = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Subject>>(jsonString);
    }

    public static void AppendToFile(Subject subject)
    {
        var subjects = ReadFromFile();
        subjects.Add(subject);
        string jsonString = JsonSerializer.Serialize(subjects);
        File.WriteAllText(FileName, jsonString);
    }

    public static void DisplaySubjects(List<Subject> subjects)
    {
        if (subjects.Count == 0)
        {
            Console.WriteLine("Нічого не знайдено.");
        }
        else
        {
            foreach (var subject in subjects)
            {
                Console.WriteLine(subject + "\n");
            }
        }
    }

    public static List<Subject> FindBySubjectName(List<Subject> subjects, string subjectName)
    {
        return subjects.Where(s => s.Name.Contains(subjectName, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static List<Subject> FindByLecturer(List<Subject> subjects, string lecturer)
    {
        return subjects.Where(s => s.Lecturer.Contains(lecturer, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public static List<Subject> FindByCourseWork(List<Subject> subjects, bool hasCourseWork)
    {
        return subjects.Where(s => s.HasCourseWork == hasCourseWork).ToList();
    }

    public static List<Subject> FindBySemester(List<Subject> subjects, int semester)
    {
        return subjects.Where(s => s.Semester == semester).ToList();
    }
}