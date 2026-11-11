using System.Text;

namespace languagecourses;

internal class Program
{
    static void Main(string[] args)
    {
        // щоб показували нормальну українські букви в консолі
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        bool running = true;
        while (running)
        {
            Console.WriteLine("Курси іноземних мов");
            Console.WriteLine("1 - про програму (довідка)");
            Console.WriteLine("2 - таблиця вартості навчання");
            Console.WriteLine("3 - таблиця годин по групах");
            Console.WriteLine("4 - змінити запис");
            Console.WriteLine("5 - видалити запис");
            Console.WriteLine("6 - зведена таблиця");
            Console.WriteLine("7 - зберегти у файл");
            Console.WriteLine("8 - завантажити у файлу");
            Console.WriteLine("9 - експорт у CVS");
            Console.WriteLine("0 - вихід");
            Console.WriteLine("ваш вибір: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
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

                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Вартість курсу залежно від тривалості:");
                    Console.WriteLine($"{"Місяців",8} {"Сума (грн)",14}");

                    double from = 1.0;
                    double to = 5.0;
                    double step = 0.5;
                    double pricePerMonth = 2000.0;

                    // + 1e-9 щоб не зник останній рядок через похибку double
                    for (double x = from; x <= to + 1e-9; x += step)
                    {
                        double y = x * pricePerMonth - Math.Sqrt(x) * 150;
                        
                    }
                    
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                
                case "3":
                    Console.WriteLine("Введіть кількість груп (рядків): ");
            }

        }
    }
}