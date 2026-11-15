using System.Globalization;
using System.Text;

namespace languagecourses;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

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
                    ShowCostTable(); Pause(); break;
                case "3":
                case "4":
                case "5":
                case "6":
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
        PrintCostTable(1.0, 5.0, 0.5);
    }

}