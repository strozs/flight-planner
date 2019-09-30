using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flight_planner.Models
{
    public static class FlightStorage
    {
        private static int _id;
        static FlightStorage()
        {
            _flights = new List<Flight>();
            _id = 1;
        }

        private static List<Flight> _flights { get; set; }

        public static bool AddFlight(Flight flight)
        {
            if (!_flights.Any(f => f.Equals(flight)))
            {
                _flights.Add(flight);
                return true;
            }
            return false;
        }

        public static void RemoveFlight (Flight flight)
        {
            _flights.Remove(flight);
        }

        public static void RemoveFlightById (int id)
        {
            var flight = GetFlightById(id);
            if (flight != null)
            {
                _flights.Remove(flight);
            }
        }

        public static void ClearList()
        {
            _flights.Clear();
        }

        public static int GetId ()
        {
            return _id++;
        }

        public static Flight GetFlightById (int id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }
    }
}