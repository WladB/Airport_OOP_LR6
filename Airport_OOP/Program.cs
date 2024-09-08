using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Airport_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightInformationSystem fs = new FlightInformationSystem();
            List<Flight> flights = new List<Flight>();
            FlightQueryHandler queryHandler = new FlightQueryHandler();
            flights = fs.OpenJsonF();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("+++++++++++++++++++++++++++ Меню +++++++++++++++++++++++++++");
                Console.WriteLine("1. Повернути всi рейси, якi здiйснюються певною авiакомпанiєю. Рейси повиннi бути вiдсортованi по часу вильоту.");
                Console.WriteLine("2. Повернути всi рейси, якi на даний момент затримуються. Рейси повиннi бути вiдсортованi по часу затримки.");
                Console.WriteLine("3. Повернути всi рейси, якi вилiтають в певний день. Рейси повиннi бути вiдсортованi по часу вильоту");
                Console.WriteLine("4. Повернути всi рейси, якi вилiтають та прибувають у вказаний промiжок часу");
                Console.WriteLine("5. Повернути всi рейси, якi прибули за останню годину або за вказаний промiжок часу. Рейси повиннi бути вiдсортованi по часу прибуття.");
                Console.WriteLine("6. Зберегти в файл");
                Console.WriteLine("7. Вихiд");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.Write("Оберiть пункт меню: ");

                string input = Console.ReadLine();
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
                switch (input)
                {
                    case "1":
                        Console.WriteLine("\nОберiть авiа компанiю: ");
                        string company = Console.ReadLine();
                        queryHandler.GetReisCompany(company, flights);
                        break;
                    case "2":
                        Console.WriteLine("\nВсi рейси, що затримуються: ");
                        queryHandler.GetDelayedReis(flights);
                        break;

                    case "3":
                        Console.WriteLine("\nВведiть рiк: ");
                        string y = Console.ReadLine();
                        Console.WriteLine("\nВведiть мiсяць: ");
                        string m = Console.ReadLine();
                        Console.WriteLine("\nВведiть число: ");
                        string d = Console.ReadLine();
                        queryHandler.GetReisDepartingThisDay($"{y}-{m}-{d}", flights);
                        break;

                    case "4":
                        Console.WriteLine("\nВведiть початок промiжку (Наприклад 2023-05-1T00:00:01): ");
                        string pr1 = Console.ReadLine();
                        Console.WriteLine("\nВведiть кiнець промiжку (Наприклад 2023-05-31T23:59:59): ");
                        string pr2 = Console.ReadLine();
                        queryHandler.GetReisOnPeriod(pr1, pr2, flights);
                        break;

                    case "5":
                        Console.WriteLine("\nВведiть поточний час (Наприклад 2023-05-31T23:59:59): ");
                        string nowTime = Console.ReadLine();
                        Console.WriteLine("\nВведiть кiлькiсть годин для промiжку: ");
                        int hours = Convert.ToInt32(Console.ReadLine());
                        queryHandler.GetReisArrivedLastHour(nowTime, hours, flights);
                        break;

                    case "6":
                        fs.SaveJsonF(flights);
                        Console.WriteLine("Данi було успiшно збережено в файл");
                        break;

                    case "7":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Невiрний вибiр, спробуйте ще раз.");
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("\nНатиснiть будь-яку клавiшу, щоб продовжити...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
    }
}
