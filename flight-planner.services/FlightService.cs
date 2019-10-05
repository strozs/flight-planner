using flight_planner.core.Models;
using flight_planner.data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_planner.services
{
    public class FlightService
    {
        private static List<Flight> _flights { get; set; }
        public async Task<ICollection<Flight>> GetFlights()
        {
            using (var context = new FlightPlannerDbContext())
            {
                return await context.Flights.Include(f => f.To).Include(f => f.From).ToListAsync();
            }
        }

        public async Task<Flight> AddFlight(Flight flight)
        {
            using (var context = new FlightPlannerDbContext())
            {
                context.Flights.Add(flight);
                await context.SaveChangesAsync();
                return flight;
            }
        }

        public async Task<bool> Exists(Flight flight)
        {
            using (var context = new FlightPlannerDbContext())
            {
                return await context.Flights.AnyAsync(f => f.Equals(flight));
            }
        }

        /*public async Task<Flight> GetFlightById(int id)
        {
            using (var context = new FlightPlannerDbContext())
            {
                return await context._flights(f => f.id == id);
            }
        }*/

    }
}
