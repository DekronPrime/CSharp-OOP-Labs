using SimpleClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть кількість студентів: ");
            int studentsCount;
            var inputStudentsCount = Console.ReadLine();
            while (!int.TryParse(inputStudentsCount, out studentsCount) || studentsCount <= 0)
            {
                Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                Console.Write("Введіть кількість студентів: ");
                inputStudentsCount = Console.ReadLine();
            }

            var students = CreateStudents(studentsCount);

            Console.WriteLine("\n\tСписок студентів:");
            DisplayStudents(students);

            string? choice;
            do
            {
                Console.WriteLine("\n1 - Показати середній бал студента");
                Console.WriteLine("2 - Показати найгірший предмет студента");
                Console.WriteLine("3 - Показати вартість навчання студента");
                Console.WriteLine("0 - Вихід");
                Console.Write("Оберіть умову: ");
                choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\t1 - Показати середній бал студента");
                        DisplayStudentsNames(students);
                        int averagePointIndex;
                        Console.Write("Введіть номер студента: ");
                        var inputAveragePointIndex = Console.ReadLine();
                        while (!int.TryParse(inputAveragePointIndex, out averagePointIndex) || averagePointIndex < 0 || averagePointIndex > students.Length)
                        {
                            Console.WriteLine("Неправильне значення. Це має бути ціле число в межах маисву. Спробуйте знову!");
                            Console.Write("Введіть номер студента: ");
                            inputAveragePointIndex = Console.ReadLine();
                        }
                        Console.WriteLine($"Середній бал: {students[averagePointIndex - 1].GetAveragePoint():F2}/100");
                        break;

                    case "2":
                        Console.WriteLine("\t2 - Показати найгірший предмет студента");
                        DisplayStudentsNames(students);
                        int worstSubjectIndex;
                        Console.Write("Введіть номер студента: ");
                        var inputWorstSubjectIndex = Console.ReadLine();
                        while (!int.TryParse(inputWorstSubjectIndex, out worstSubjectIndex) || worstSubjectIndex < 0 || worstSubjectIndex > students.Length)
                        {
                            Console.WriteLine("Неправильне значення. Це має бути ціле число в межах маисву. Спробуйте знову!");
                            Console.Write("Введіть номер студента: ");
                            inputWorstSubjectIndex = Console.ReadLine();
                        }
                        Console.WriteLine($"Найгірший предмет: {students[worstSubjectIndex - 1].GetWorstSubject()}");
                        break;

                    case "3":
                        Console.WriteLine("\t3 - Показати вартість навчання студента");
                        DisplayStudentsNames(students);
                        int monthlyFeeIndex;
                        Console.Write("Введіть номер студента: ");
                        var inputMonthlyFeeIndex = Console.ReadLine();
                        while (!int.TryParse(inputMonthlyFeeIndex, out monthlyFeeIndex) || monthlyFeeIndex < 0 || monthlyFeeIndex > students.Length)
                        {
                            Console.WriteLine("Неправильне значення. Це має бути ціле число в межах маисву. Спробуйте знову!");
                            Console.Write("Введіть номер студента: ");
                            inputMonthlyFeeIndex = Console.ReadLine();
                        }
                        students[monthlyFeeIndex - 1].DisplayFee();
                        break;
                    case "0":
                        return;

                    default:
                        Console.WriteLine("Немає такої умови\n");
                        break;
                }
            } while (choice != "0");
        }

        public static Student[] CreateStudents(int count)
        {
            var students = new Student[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"\n(С-{i + 1}) Введіть ПІБ студента: ");
                string? fullName = Console.ReadLine();

                Console.Write($"(С-{i + 1}) Введіть шифр групи: ");
                string? group = Console.ReadLine();

                int courseNumber;
                Console.Write($"(С-{i + 1}) Введіть номер курсу: ");
                var inputCourseNumber = Console.ReadLine();
                while (!int.TryParse(inputCourseNumber, out courseNumber) || courseNumber <= 0)
                {
                    Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                    Console.Write($"(С-{i + 1}) Введіть номер курсу: ");
                    inputCourseNumber = Console.ReadLine();
                }

                int resultCount;
                Console.Write($"(С-{i + 1}) Введіть кількість результатів: ");
                var inputResultCount = Console.ReadLine();
                while (!int.TryParse(inputResultCount, out resultCount) || resultCount <= 0)
                {
                    Console.WriteLine("Неправильне значення. Це має бути ціле число > 0. Спробуйте знову!");
                    Console.Write($"(С-{i + 1}) Введіть кількість результатів: ");
                    inputCourseNumber = Console.ReadLine();
                }
                var results = new Result[resultCount];

                for (int j = 0; j < resultCount; j++)
                {
                    Console.Write($"\n(Р-{j + 1}) Введіть назву предмета: ");
                    string? subjectName = Console.ReadLine();

                    Console.Write($"(Р-{j + 1}) Введіть ПІБ викладача: ");
                    string? teacherFullName = Console.ReadLine();

                    bool isExam = false;
                    Console.Write($"(Р-{j + 1}) Чи є екзамен? (так (1), ні (0)): ");
                    var inputHasExam = Console.ReadLine();
                    do
                    {
                        if (inputHasExam == "1")
                        {
                            isExam = true;
                        }
                        else if (inputHasExam != "0")
                        {
                            Console.WriteLine("Такого варіанту не передбачено");
                            Console.Write($"(Р-{j + 1}) Чи є екзамен? (так (1), ні (0)): ");
                            inputHasExam = Console.ReadLine();
                        }
                    }
                    while (inputHasExam != "1" && inputHasExam != "0");

                    int points;
                    Console.Write($"(Р-{j + 1}) Введіть оцінку (0-100): ");
                    var inputPoints = Console.ReadLine();
                    while (!int.TryParse(inputPoints, out points) || points < 0 || points > 100)
                    {
                        Console.WriteLine("Неправильне значення. Це має бути ціле число в діапазоні від 0 до 100. Спробуйте знову!");
                        Console.Write($"(Р-{j + 1}) Введіть оцінку (0-100): ");
                        inputCourseNumber = Console.ReadLine();
                    }
                    results[j] = new Result(subjectName, teacherFullName, isExam, points);
                }
                students[i] = new Student(fullName, group, courseNumber, results);
                students[i].InputFee();
            }
            return students;
        }

        public static void DisplayStudents(Student[] students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student + "\n");
            }
        }

        public static void DisplayStudentsNames(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"({i + 1}) " + students[i].FullName);
            }
        }
    }
}