using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Airport_OOP
{
    public class FlightInformationSystem
    {
        public DateTime CorDate(string date)
        {
            string[] formats = { "dd.MM.yyyy H:mm:ss", "yyyy-MM-ddTHH:mm:ss", "yyyy-dd-MMTHH:mm:ss" };
            DateTime parsedDate;
            DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            return parsedDate;
        }
        public void SaveJsonF(List<Flight> flights)
        {
            File.WriteAllText("SaveJson.txt", JsonConvert.SerializeObject(new Dictionary<string, List<Flight>> { { "flights", flights } }, Formatting.Indented));
        }
        public List<Flight> OpenJsonF()
        {
            try
            {
                string str = File.ReadAllText("flights_data.json");
                JObject jsonObject = JObject.Parse(str);
                JArray flightsArray = (JArray)jsonObject["flights"];
                List<Flight> flights = new List<Flight>();

                foreach (JObject flightObject in flightsArray)
                {
                    Flight flight = new Flight();
                    flight.FlightNumber = (string)flightObject["FlightNumber"];
                    flight.Airline = (string)flightObject["Airline"];
                    flight.Destination = (string)flightObject["Destination"];
                    flight.DepartureTime = CorDate(flightObject["DepartureTime"].ToString());
                    flight.ArrivalTime = CorDate(flightObject["ArrivalTime"].ToString());
                    flight.Status = flightObject["Status"] != null ? (FlightStatus)Enum.Parse(typeof(FlightStatus), flightObject["Status"].ToString()) : FlightStatus.Cancelled;
                    flight.Duration = flightObject["Duration"].ToString() != "" ? (TimeSpan)flightObject["Duration"] : (TimeSpan)(CorDate(flightObject["ArrivalTime"].ToString()) - CorDate(flightObject["DepartureTime"].ToString()));
                    flight.AircraftType = (string)flightObject["AircraftType"];
                    flight.Terminal = (string)flightObject["Terminal"];

                    flights.Add(flight);
                }
                return flights;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nНевдалося зчитати файл(");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("=======================");
                return null;
            }
        }
        public static void SortByDepartureTime(List<Flight> fts)
        {
            fts.Sort((f1, f2) => f1.DepartureTime.CompareTo(f2.DepartureTime));
        }
        public static void SortByDelay(List<Flight> fts)
        {
            fts.Sort((f1, f2) => f1.Delay().CompareTo(f2.Delay()));
        }
        public static void SortByArrivalTime(List<Flight> fts)
        {
            fts.Sort((f1, f2) => f1.ArrivalTime.CompareTo(f2.ArrivalTime));
        }
    }
}
