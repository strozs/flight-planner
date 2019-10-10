using flight_planner.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_planner.core1.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Task<IEnumerable<Flight>> GetFlights();
        Task<ServiceResult> AddFlight(Flight flight);
        Task<Flight> GetFlightById(int id);
        Task<ServiceResult> DeleteFlightById(int id);
        Task<bool> FlightExists(Flight flight);
        Task DeleteFlights();
    }
}
