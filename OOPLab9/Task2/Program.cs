namespace Task2 
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Journal journal1 = new Journal("Наука", 50, 120, 8);
            Journal journal2 = new Journal("Техніка", 40, 90, 10);
            Journal journal3 = new Journal("Культура", 60, 80, 6);
            Journal journal4 = new Journal("Подорожі", 45, 110, 7);
            Journal journal5 = new Journal("Спорт", 35, 100, 9);

            Journal[] journals = { journal1, journal2, journal3, journal4, journal5 };

            Console.WriteLine("Поточний вигляд масиву журналів:");
            PrintJournals(journals);

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1 - Сортувати журнали за ціною");
                Console.WriteLine("2 - Сортувати журнали за кількістю сторінок");
                Console.WriteLine("3 - Сортувати журнали за рейтингом продажів");
                Console.WriteLine("4 - Вивести журнали у порядку спадання рейтингу (IEnumerable)");
                Console.WriteLine("0 - Вийти");
                Console.Write("Оберіть дію: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Array.Sort(journals);
                        Console.WriteLine("\nЖурнали відсортовані за ціною:");
                        PrintJournals(journals);
                        break;

                    case "2":
                        Array.Sort(journals, new PageComparer());
                        Console.WriteLine("\nЖурнали відсортовані за кількістю сторінок:");
                        PrintJournals(journals);
                        break;

                    case "3":
                        Array.Sort(journals, new SalesRatingComparer());
                        Console.WriteLine("\nЖурнали відсортовані за рейтингом продажів:");
                        PrintJournals(journals);
                        break;

                    case "4":
                        JournalList collection = new JournalList();
                        foreach (var journal in journals) 
                            collection.Add(journal);

                        Console.WriteLine("\nЖурнали відсортовані у порядку спадання рейтингу продажів (IEnumerable):");
                        PrintJournals(collection);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте знову.");
                        break;
                }
            }
        }

        public static void PrintJournals(IEnumerable<Journal> journals)
        {
            foreach (var journal in journals)
            {
                Console.WriteLine(journal);
            }
        }
    }
}