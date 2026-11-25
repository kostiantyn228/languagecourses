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
                    PrintStudents(contracts, surnames, languages, levelIds, groups,
                        startDates, paidMonths, scores, count);
                    Pause();
                    break;
                case "2":
                    AddStudent(contracts, surnames, languages, levelIds, groups,
                        startDates, paidMonths, scores, ref count, ref nextId);
                    Pause();
                    break;
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                    FillSampleData(contracts, surnames, languages, levelIds, groups,
                        startDates, paidMonths, scores, ref count, ref nextId);
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
    
    // Виводить усі записи таблицею з вирівняними стовпцями. Перебір до count, а не до Length
    static void PrintStudents(string[] contracts, string[] surnames, string[] languages,
        int[] levelIds, string[] groups, DateTime[] startDates, int[] paidMonths,
        double[] scores, int count)
    {
        if (count == 0)
        {
            Console.WriteLine("Записів поки немає.");
            return;
        }
        Console.WriteLine($"{"Договір",-9}{"Прізвище",-16}{"Мова",-13}{"Рівень",7} " +
                          $"{"Група",-8}{"Початок",11}{"Міс.",6}{"Бал",8}");
        Console.WriteLine(new string('-', 79));
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{contracts[i],-9}{surnames[i],-16}{languages[i],-13}{levelIds[i],7} " +
                              $"{groups[i],-8}{startDates[i],11:dd.MM.yyyy}{paidMonths[i],6}{scores[i],8:F1}");
        }
        Console.WriteLine($"\nЗаписів: {count}.");
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
    
    static string ReadText(string prompt, int minLength)
{
    while (true)
    {
        Console.Write(prompt);
        string text = Console.ReadLine();
        if (text != null)
        {
            text = text.Trim();
            if (text.Length >= minLength)
            {
                return text;
            }
        }
        Console.WriteLine($"Помилка: введіть не менше {minLength} симв.");
    }
}

// Читає дату у форматі дд.мм.рррр: існуючу й не з майбутнього
static DateTime ReadDate(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string text = Console.ReadLine();
        if (!DateTime.TryParseExact(text, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime date))
        {
            Console.WriteLine("Помилка: дата має бути у форматі дд.мм.рррр, наприклад 01.09.2026.");
            continue;
        }
        if (date > DateTime.Today)
        {
            Console.WriteLine("Помилка: дата початку не може бути в майбутньому.");
            continue;
        }
        return date;
    }
}

// Додає слухача: спершу збирає всі поля в локальні змінні, потім пише у масиви.
// count і nextId передаються через ref, бо метод їх змінює
static void AddStudent(string[] contracts, string[] surnames, string[] languages,
    int[] levelIds, string[] groups, DateTime[] startDates, int[] paidMonths,
    double[] scores, ref int count, ref int nextId)
{
    // contracts.Length - це і є Capacity
    if (count == contracts.Length)
    {
        Console.WriteLine("Сховище заповнене, видаліть щось зайве.");
        return;
    }

    string surname = ReadText("Прізвище: ", 2);
    string language = ReadText("Мова: ", 2);
    int levelId = ReadInt("Код рівня (1-6): ", 1, 6);
    string group = ReadText("Група: ", 1).ToUpper(); // щоб «en-1» і «EN-1» були однією групою
    DateTime start = ReadDate("Дата початку (дд.мм.рррр): ");
    int months = ReadInt("Оплачено місяців (0-24): ", 0, 24);
    double score = ReadDouble("Поточний бал (0-100): ", 0, 100);

    // усі масиви заповнюються тут, під одним індексом
    contracts[count] = "Д-" + nextId.ToString("D3"); // номер призначає програма
    surnames[count] = surname;
    languages[count] = language;
    levelIds[count] = levelId;
    groups[count] = group;
    startDates[count] = start;
    paidMonths[count] = months;
    scores[count] = score;
    count++;
    nextId++;

    Console.WriteLine($"Додано слухача, договір {contracts[count - 1]}.");
 }

// Заповнює сховище 6 готовими записами без запитань
static void FillSampleData(string[] contracts, string[] surnames, string[] languages,
    int[] levelIds, string[] groups, DateTime[] startDates, int[] paidMonths,
    double[] scores, ref int count, ref int nextId)
{
    string[] sSurnames = { "Коваленко", "Шевченко", "Бондаренко", "Мельник", "Ткаченко", "Кравчук" };
    string[] sLanguages = { "англійська", "англійська", "німецька", "німецька", "польська", "англійська" };
    int[] sLevels = { 2, 2, 3, 3, 1, 4 };
    string[] sGroups = { "EN-1", "EN-1", "DE-1", "DE-1", "PL-1", "EN-2" };
    DateTime[] sDates =
    {
        new DateTime(2026, 9, 1), new DateTime(2026, 9, 1), new DateTime(2026, 9, 15),
        new DateTime(2026, 9, 15), new DateTime(2026, 10, 1), new DateTime(2026, 10, 10)
    };
    int[] sMonths = { 3, 3, 6, 4, 2, 5 };
    double[] sScores = { 85.5, 72, 90, 64.5, 78, 55 };

    int added = 0;
    for (int i = 0; i < sSurnames.Length; i++)
    {
        if (count == contracts.Length)
        {
            Console.WriteLine("Сховище заповнене, решту не додано.");
            break;
        }
        contracts[count] = "Д-" + nextId.ToString("D3");
        surnames[count] = sSurnames[i];
        languages[count] = sLanguages[i];
        levelIds[count] = sLevels[i];
        groups[count] = sGroups[i];
        startDates[count] = sDates[i];
        paidMonths[count] = sMonths[i];
        scores[count] = sScores[i];
        count++;
        nextId++;
        added++;
    }
    Console.WriteLine($"Додано тестових записів: {added}."); 
 }
}