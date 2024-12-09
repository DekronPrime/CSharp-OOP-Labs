using System.Collections;

namespace OOPLab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Hashtable hashTable = new Hashtable
            {
                { "ПІБ", "Тарнавський П.В." }, 
                { "Вік", 20 }, 
                { "Вага", 65.7 }, 
                { "Одружений", false } 
            };

            Console.WriteLine("Поточні дані у хеш-таблиці:");
            PrintHashTable(hashTable);

            hashTable.Add("Хоббі", "3D-Моделювання");
            hashTable.Remove("Одружений"); 
            hashTable["Місто"] = "Тернопіль"; 

            Console.WriteLine("\nОновлені дані у хеш-таблиці:");
            PrintHashTable(hashTable);

            Console.WriteLine();
            if (hashTable.ContainsValue(20))
                Console.WriteLine("Дана хеш-таблиця містить значення 20");
            else
                Console.WriteLine("Дана хеш-таблиця не містить значення 20");

            Console.WriteLine();
            if (hashTable.ContainsKey("Одружений"))
                Console.WriteLine("Дана хеш-таблиця містить ключ Одружений");
            else
                Console.WriteLine("Дана хеш-таблиця не містить ключа Одружений");

            Console.WriteLine("\nКількість елементів в хеш-таблиці: {0}", hashTable.Count);

            Console.WriteLine("\nКлючі хеш-таблиці:");
            PrintHashTableKeys(hashTable);

            Console.WriteLine("\nЗначення хеш-таблиці:");
            PrintHashTableValues(hashTable);

            hashTable.Clear();

            return;
        }

        public static void PrintHashTable(Hashtable hashTable) {
            foreach (DictionaryEntry entry in hashTable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        public static void PrintHashTableKeys(Hashtable hashTable)
        {
            foreach (var key in hashTable.Keys)
            {
                Console.WriteLine(key);
            }
        }

        public static void PrintHashTableValues(Hashtable hashTable)
        {
            foreach (var value in hashTable.Values)
            {
                Console.WriteLine(value);
            }
        }
    }
}