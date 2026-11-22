using System.Globalization;
using System.Text;

namespace languagecourses;

internal class Program
{
    static void Main(string[] args)
    {
            Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // сховище слухачів: по масиву на кожне поле, Capacity - місткість
        const int Capacity = 100;
        string[] contracts = new string[Capacity];   // номер договору
        string[] surnames = new string[Capacity];    // прізвище
        string[] languages = new string[Capacity];   // мова
        int[] levelIds = new int[Capacity];          // код рівня з довідника
        string[] groups = new string[Capacity];      // група
        DateTime[] startDates = new DateTime[Capacity]; // дата початку
        int[] paidMonths = new int[Capacity];        // оплачено місяців
        double[] scores = new double[Capacity];      // поточний бал
        int count = 0;
        int nextId = 1;

        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    ShowNotReady();
                    Pause();
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("До побачення.");
                    break;
                default:
                    Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
                    Pause();
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Курси іноземних мов");
        Console.WriteLine("1 - показати всі записи");
        Console.WriteLine("2 - додати запис");
        Console.WriteLine("3 - знайти за умовою");
        Console.WriteLine("4 - змінити запис");
        Console.WriteLine("5 - видалити запис");
        Console.WriteLine("6 - зведена таблиця");
        Console.WriteLine("7 - зберегти у файл");
        Console.WriteLine("8 - завантажити з файлу");
        Console.WriteLine("9 - експорт у CSV");
        Console.WriteLine("10 - заповнити тестовими даними");
        Console.WriteLine("0 - вихід");
        Console.Write("Ваш вибір: ");
    }

    static void Pause()
    {
        Console.WriteLine("\nНатисніть будь-яку клавішу...");
        Console.ReadKey(true);
        Console.Clear();
    }

    static void ShowNotReady()
    {
        Console.WriteLine("Поки не зроблено.");
    }

    static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out int value))
            {
                Console.WriteLine("Помилка: введіть ціле число.");
                continue;
            }
            if (value < min || value > max)
            {
                Console.WriteLine($"Помилка: число має бути від {min} до {max}.");
                continue;
            }
            return value;
        }
    }

    static double ReadDouble(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            string text = Console.ReadLine();
            // кома й крапка обидві приймаються
            if (text == null || !double.TryParse(text.Trim().Replace(',', '.'),
                    NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
            {
                Console.WriteLine("Помилка: введіть число.");
                continue;
            }
            if (value < min || value > max)
            {
                Console.WriteLine($"Помилка: число має бути від {min} до {max}.");
                continue;
            }
            return value;
        }
    }
}