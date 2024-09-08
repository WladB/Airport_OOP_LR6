using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_OOP
{
    public class FlightQueryHandler
    {
        public void GetReisCompany(string nameAirline, List<Flight> flights)
        {
            try
            {
                FlightInformationSystem.SortByDepartureTime(flights);
                for (int i = 0; i < flights.Count; i++)
                {
                    if (flights[i].Airline == nameAirline)
                    {
                        flights[i].ConsoleWrite();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Щось не спрацювало(");
                Console.WriteLine("=======================");
            }
        }
        public void GetDelayedReis(List<Flight> flights)
        {
            try
            {
                FlightInformationSystem.SortByDelay(flights);
                for (int i = 0; i < flights.Count; i++)
                {
                    if (flights[i].Status == FlightStatus.Delayed)
                    {
                        flights[i].ConsoleWrite();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                        Console.WriteLine("Затримка: " + ((flights[i].ArrivalTime - flights[i].DepartureTime) - flights[i].Duration));
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Щось не спрацювало(");
                Console.WriteLine("=======================");
            }
        }
        public void GetReisDepartingThisDay(string day, List<Flight> flights)
        {
            try
            {
                FlightInformationSystem.SortByDepartureTime(flights);
                for (int i = 0; i < flights.Count; i++)
                {
                    if (flights[i].DepartureTime.Date == DateTime.Parse(day).Date)
                    {
                        flights[i].ConsoleWrite();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Щось не спрацювало(");
                Console.WriteLine("=======================");
            }
        }
        public void GetReisOnPeriod(string Date1, string Date2, List<Flight> flights)
        {
            try
            {
                FlightInformationSystem.SortByDepartureTime(flights);
                for (int i = 0; i < flights.Count; i++)
                {
                    if (flights[i].Destination != "")
                    {
                        if ((flights[i].DepartureTime >= DateTime.Parse(Date1) && flights[i].DepartureTime <= DateTime.Parse(Date2)) &&
                            flights[i].ArrivalTime >= DateTime.Parse(Date1) && flights[i].ArrivalTime <= DateTime.Parse(Date2))
                        {
                            flights[i].ConsoleWrite();
                            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Щось не спрацювало(");
                Console.WriteLine("=======================");
            }
        }
        public void GetReisArrivedLastHour(string DateTimeNow, List<Flight> flights)
        {
            try
            {
                FlightInformationSystem.SortByDepartureTime(flights);
                for (int i = 0; i < flights.Count; i++)
                {
                    if (flights[i].ArrivalTime >= DateTime.Parse(DateTimeNow).AddHours(-1) && flights[i].ArrivalTime <= DateTime.Parse(DateTimeNow))
                    {
                        flights[i].ConsoleWrite();
                        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Щось не спрацювало(");
                Console.WriteLine("=======================");
            }
        }

        public void GetReisArrivedLastHour(string DateTimeNow, int Period, List<Flight> flights)
        {
            try
            {
                FlightInformationSystem.SortByArrivalTime(flights);
                for (int i = 0; i < flights.Count; i++)
                {
                    if (flights[i].Destination != "")
                    {
                        if ((flights[i].ArrivalTime >= DateTime.Parse(DateTimeNow).AddHours(-1 * Math.Abs(Period)) && flights[i].ArrivalTime <= DateTime.Parse(DateTimeNow)))
                        {
                            flights[i].ConsoleWrite();
                            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Щось не спрацювало(");
                Console.WriteLine("=======================");
            }
        }
    }
}
