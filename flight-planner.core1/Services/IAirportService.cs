using flight_planner.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_planner.core1.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        Task<IEnumerable<Airport>> SearchAirports(string search);
    }
}
