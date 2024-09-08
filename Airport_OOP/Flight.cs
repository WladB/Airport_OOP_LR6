using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Airport_OOP
{
    public class Flight
    {
        public string FlightNumber;
        public string Airline;
        public string Destination;
        public DateTime DepartureTime;
        public DateTime ArrivalTime;
        public FlightStatus Status;
        public TimeSpan Duration;
        public string AircraftType;
        public string Terminal;

        public void ConsoleWrite() {
            Console.WriteLine($"FlightNumber: {FlightNumber}");
            Console.WriteLine($"Airline: {Airline}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"DepartureTime: {DepartureTime}");
            Console.WriteLine($"ArrivalTime: {ArrivalTime}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Duration: {Duration}");
            Console.WriteLine($"AircraftType: {AircraftType}");
            Console.WriteLine($"Terminal: {Terminal}");
        }
        public TimeSpan Delay()
        {
            return (ArrivalTime - DepartureTime) - Duration;
        }
    }
    public enum FlightStatus : byte
    {
        OnTime,
        Delayed,
        Cancelled,
        Boarding,
        InFlight
    }
}
