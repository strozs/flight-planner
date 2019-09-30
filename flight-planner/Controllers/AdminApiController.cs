using flight_planner.Atribute;
using flight_planner.Models;
using javax.naming.directory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace flight_planner.Controllers
{
    [BasicAuthentication]
    public class AdminApiController : ApiController
    {
        private Random _random;
        //private static FlightStorage _storage;
        public AdminApiController()
        {
            _random = new Random();
        }
        // GET: api/AdminApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminApi/5
        [Route("admin-api/flights/{id}")]
        public Flight Get(int id)
        {
            return FlightStorage.GetFlightById(id);
            
        }

        // POST: api/AdminApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AdminApi/5
        [HttpPut]
        [Route("admin-api/flights")]
        public HttpResponseMessage AddFlight(HttpRequestMessage request, Flight flight)
        {
            if (IsValid(flight))
            {
                flight.Id = FlightStorage.GetId();

                if (!FlightStorage.AddFlight(flight))
                {
                    return request.CreateResponse(HttpStatusCode.Conflict, flight);
                }

                return request.CreateResponse(HttpStatusCode.Created, flight);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest,flight);
            }
            
        }

        private bool IsValid (Flight flight)
        {
            var result = false;
            if (!string.IsNullOrEmpty(flight.ArrivalTime) && 
                !string.IsNullOrEmpty(flight.DepartureTime) && 
                !string.IsNullOrEmpty(flight.Carrier) &&
                IsValidAirport(flight.From) && IsValidAirport(flight.To) && flight.From.Airport.ToLower().Trim() != flight.To.Airport.ToLower().Trim())
                
            {
                result = true;
            }

            return result;
        }

        private bool IsValidAirport (AirportRequest airport)
        {
            return airport != null && !string.IsNullOrEmpty(airport.Airport) &&
                !string.IsNullOrEmpty(airport.City) &&
                !string.IsNullOrEmpty(airport.Country);
        }

        private bool ValidateDates(string departure, string arrival)
        {
            if (!string.IsNullOrEmpty(departure) && !string.IsNullOrEmpty(arrival))
            {
                var departureDate = DateTime.Parse(departure);
                var arrivalDate = DateTime.Parse(arrival);
                return DateTime.Compare(arrivalDate, departureDate) > 0;
            }

            return false;
        }

        // DELETE: api/AdminApi/5
        [HttpDelete]
        [Route("admin-api/flights/{id}")]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, int id)
        {
            FlightStorage.RemoveFlightById(id);
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
