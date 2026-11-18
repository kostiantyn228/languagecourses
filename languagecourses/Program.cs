using System.Globalization;
using System.Text;

namespace languagecourses;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        const int Capacity = 100;
        double[] scores = new double[Capacity];
        int count = 0;
        
        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ShowAbout();
                    Pause();
                    break;
                case "2":
                    ShowCostTable();
                    Pause();
                    break;
                case "3":
                    ShowHoursTable();
                    Pause();  
                    break;
                case "4":
                    double newScore = ReadDouble("Поточний бал (від 0 до 100): ", 0, 100);
                    int before = count;
                    AddValue(scores, ref count, newScore, Capacity);
                    Console.WriteLine($"Лічильник: було {before}, стало {count}.");
                    Pause();
                    break;
                case "5":
                case "6":
                    PrintValues(scores, count);
                    if (count > 0)
                    {
                        Statistics(scores, count, out double sum, out double average);
                        FindMax(scores, count, out double max, out int maxNumber);
                        Console.WriteLine($"\nЗначень: {count}");
                        Console.WriteLine($"Сума: {sum:F2}");
                        Console.WriteLine($"Середній бал: {average:F2}");
                        Console.WriteLine($"Найбільший: {max:F1} (№ {maxNumber})");
                    }
                    Pause();
                    break;
                case "7":
                case "8":
                case "9":
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
        Console.WriteLine("1 - про програму (довідка)");
        Console.WriteLine("2 - таблиця вартості навчання");
        Console.WriteLine("3 - таблиця годин по групах");
        Console.WriteLine("4 - змінити запис");
        Console.WriteLine("5 - видалити запис");
        Console.WriteLine("6 - зведена таблиця");
        Console.WriteLine("7 - зберегти у файл");
        Console.WriteLine("8 - завантажити з файлу");
        Console.WriteLine("9 - експорт у CSV");
        Console.WriteLine( "1- дослід: значиме та посилальне");
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

    static void ShowAbout()
    {
        Console.WriteLine("Тема: №15. Курси іноземних мов");
        Console.WriteLine("Сутність: Слухач (8 полів), Довідник: Рівень\n");
        Console.WriteLine("Поля запису:");
        Console.WriteLine("- номер договору (string)");
        Console.WriteLine("- прізвище (string)");
        Console.WriteLine("- мова (string)");
        Console.WriteLine("- код рівня з довідника (int)");
        Console.WriteLine("- група (string)");
        Console.WriteLine("- дата початку (DateTime)");
        Console.WriteLine("- оплачено місяців (int)");
        Console.WriteLine("- поточний бал (double)\n");
        Console.WriteLine("Підсумкова величина: середній бал по кожній групі.");
    }

    static double CalculateCost(double months, double pricePerMonth)
    {
        return months * pricePerMonth - Math.Sqrt(months) * 150;
    }

    static void PrintCostTable(double from, double to, double step)
    {
        Console.WriteLine("Вартість курсу залежить від тривалості");
        Console.WriteLine($"{"Місяців",8} {"Сума (грн)",14}");
        
        // + 1e-9, щоб не зник останній рядок через похибку double
        for (double x = from; x <= to + 1e-9; x += step)
        {
            double y = CalculateCost(x, 2000.0);
            Console.WriteLine($"{x,8:F1} {y,14:F2}");
        }
    }

    static void ShowCostTable()
    {
        double from = ReadDouble("Початок (місяців, від 1 до 24): ", 1, 24);
        double to = ReadDouble("Кінець (місяців): ", from, 24);
        double step = ReadDouble("Крок (від 0,1 до 12): ", 0.1, 12);
        PrintCostTable(from, to, step);
    }
    static int CalculateHours(int group, int month)
    {
        return 10 + group * 2 + month;
    }

    static void PrintHoursTable(int rows, int cols)
    {
        Console.WriteLine();
        Console.Write($"{"Група",-10}");
        for (int col = 1; col <= cols; col++)
            Console.Write($"{col,8}");
        Console.WriteLine($"{"Разом",10}");

        int total = 0;
        for (int row = 1; row <= rows; row++)
        {
            int rowSum = 0;
            Console.Write($"{"Гр-" + row,-10}");
            for (int col = 1; col <= cols; col++)
            {
                int hours = CalculateHours(row, col);
                Console.Write($"{hours,8}");
                rowSum += hours;
            }
            total += rowSum;
            Console.WriteLine($"{rowSum,10}");
        }

        Console.Write($"{"Усього",-10}");
        for (int col = 1; col <= cols; col++)
        {
            int colSum = 0;
            for (int row = 1; row <= rows; row++)
                colSum += CalculateHours(row, col);
            Console.Write($"{colSum,8}");
        }
        Console.WriteLine($"{total,10}");
    }

    static void ShowHoursTable()
    {
        int rows = ReadInt("Кількість груп (рядків, від 1 до 20): ", 1, 20);
        int cols = ReadInt("Кількість місяців (стовпців, від 1 до 12): ", 1, 12);
        PrintHoursTable(rows, cols); 
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
    
    static void AddValue(double[] values, ref int count, double newValue, int capacity)
    {
        if (count == capacity)
        {
            Console.WriteLine("місця більше немає.");
            return;
        }
        values[count] = newValue;
        count++;
    }
    static void PrintValues(double[] values, int count)
    {
        if (count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }
        Console.WriteLine($"{"№",4} {"Бал",8}");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1,4} {values[i],8:F1}");
        }
    }
    static void Statistics(double[] values, int count, out double sum, out double average)
    {
        sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += values[i];
        }
        average = count > 0 ? sum / count : 0;
    }
    static void FindMax(double[] values, int count, out double max, out int maxNumber)
    {
        if (count == 0)
        {
            max = 0;
            maxNumber = 0;
            return;
        }
        max = values[0];
        maxNumber = 1;
        for (int i = 1; i < count; i++)
        {
            if (values[i] > max)
            {
                max = values[i];
                maxNumber = i + 1;
            }
        }
    }
}