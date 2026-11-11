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
            
            
            
        }
    }
}