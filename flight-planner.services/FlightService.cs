using flight_planner.core.Models;
using flight_planner.core1.Services;
using flight_planner.data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_planner.services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context) { }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await Task.FromResult(Get());
        }

        public async Task<ServiceResult> AddFlight(Flight flight)
        {
            if(await FlightExists(flight))
            {
                return new ServiceResult(false);
            }

            return Create(flight);
        }

        public async Task<Flight> GetFlightById(int id)
        {
            return await GetById(id);
        }

        public async Task<ServiceResult> DeleteFlightById(int id)
        {
            var flight = await GetById(id);
            return Delete(flight);
        }

        public async Task<bool> FlightExists(Flight flight)
        {
            return await Query().AnyAsync(f =>
                f.Carrier == flight.Carrier && f.ArrivalTime == flight.ArrivalTime &&
                f.DepartureTime == flight.DepartureTime &&
                f.From.City == flight.From.City &&
                f.From.Country == flight.From.Country &&
                f.To.Airport == flight.To.Airport &&
                f.To.City == flight.To.City &&
                f.To.Country == flight.To.Country);
        }

        public async Task DeleteFlights()
        {
            _ctx.Flights.RemoveRange(_ctx.Flights);
            _ctx.Airports.RemoveRange(_ctx.Airports);
            await _ctx.SaveChangesAsync();
        }


        /*private static List<Flight> _flights { get; set; }
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
        }*/

        /*public async Task<Flight> GetFlightById(int id)
        {
            using (var context = new FlightPlannerDbContext())
            {
                return await context.Flights(f => f.id == id);
            }
        }*/

    }
}
