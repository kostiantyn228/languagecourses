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
                    bool isRowsOk = int.TryParse(Console.ReadLine(), out int rows);

                        Console.Write("Введіть кількість місяців (стовпців): ");
                        bool isColsOk = int.TryParse(Console.ReadLine(), out int cols);

                        if (!isRowsOk || !isColsOk || rows <= 0 || cols <= 0)
                        {
                            Console.WriteLine("Помилка вводу. Розміри таблиці мають бути додатними числами.");
                        }
                    else
                    {
                        Console.WriteLine();

                        // шапка таблиці
                        Console.Write($"{"Група",-10}");
                        for (int col = 1; col <= cols; col++)
                        {
                            Console.Write($"{col,8}");
                        }

                        Console.WriteLine($"{"Разом",10}");

                        int total = 0;

                        // вивід рядків і сума по кожному рядку
                        for (int row = 1; row <= rows; row++)
                        {
                            int rowSum = 0;
                            Console.Write($"{"Гр-" + row,-10}");

                            for (int col = 1; col <= cols; col++)
                            {
                                int hours = 10 + row * 2 + col;
                                Console.Write($"{hours,8}");
                                rowSum += hours;
                            }

                            total += rowSum;
                            Console.WriteLine($"{rowSum,10}");
                        }

                        // підсумки по стовпцях знизу (рівень Б)
                        Console.Write($"{"Усього",-10}");
                        for (int col = 1; col <= cols; col++)
                        {
                            int colSum = 0;
                            for (int row = 1; row <= rows; row++)
                            {
                                int hours = 10 + row * 2 + col;
                                colSum += hours;
                            }

                            Console.Write($"{colSum,8}");
                        }

                        Console.WriteLine($"{total,10}");
                    
                    }

                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    Console.WriteLine("поки не зроблено.");
                    Console.WriteLine("\nНатисніть буль-яку клавішу...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                
                case "0":
                    running = false;
                    Console.WriteLine("До побачення.");
                    break;
                
                default:
                    Console.WriteLine("Немає такого пункту. Спробуйте ще раз.");
                    Console.WriteLine("\nНатисніть будь-яку клавішу...");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
            }

        }
    }
}