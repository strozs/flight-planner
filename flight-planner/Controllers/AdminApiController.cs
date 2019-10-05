using flight_planner.Atribute;
using flight_planner.core.Models;
using flight_planner.Models;
using flight_planner.services;
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
        private readonly FlightService _flightServices;

        public AdminApiController()
        {
            _flightServices = new FlightService();
        }


        // GET: api/AdminApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminApi/5
        [HttpGet]
        [Route("admin-api/flights/{id}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            var flight = FlightStorage.GetFlightById(id);
            if (flight == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, flight);
            }

            return request.CreateResponse(HttpStatusCode.OK, flight);
        }

        // POST: api/AdminApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AdminApi/5
        [HttpPut]
        [Route("admin-api/flights")]
        public async Task<HttpResponseMessage> AddFlight(HttpRequestMessage request, Flight flight)
        {
            /*if (!IsValid(flight))
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, flight);
                *//*flight.Id = FlightStorage.GetId();

                if (!FlightStorage.AddFlight(flight))
                {
                    return request.CreateResponse(HttpStatusCode.Conflict, flight);
                }

                return request.CreateResponse(HttpStatusCode.Created, flight);*//*
            }*/
            var domainFlight = new Flight
            {
                From = new Airport
                {
                    AirportCode = flight.From.Airport1,
                    City = flight.From.City,
                    Country = flight.From.Country
                },
                To = new Airport
                {
                    AirportCode = flight.To.Airport1,
                    City = flight.To.City,
                    Country = flight.To.Country
                },
                ArrivalTime = flight.ArrivalTime,
                Id = flight.Id,
                DepartureTime = flight.DepartureTime,
                Carrier = flight.Carrier
            };

            domainFlight = await _flightServices.AddFlight(domainFlight);

            //flight = await _flightServices.AddFlight(flight);

            return request.CreateResponse(HttpStatusCode.Created, flight);
            /*else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest,flight);
            }*/
            
        }

        [HttpGet]
        [Route("admin-api/get/flights")]
        public async Task<ICollection<Flight>> GetFlights()
        {
            return await _flightServices.GetFlights();
        }


        private bool IsValid (Flight flight)
        {
            var result = false;
            if (!string.IsNullOrEmpty(flight.ArrivalTime) && 
                !string.IsNullOrEmpty(flight.DepartureTime) && 
                !string.IsNullOrEmpty(flight.Carrier) &&
                IsValidAirport(flight.From) && IsValidAirport(flight.To) && flight.From.AirportCode.ToLower().Trim() != flight.To.AirportCode.ToLower().Trim())
                
            {
                result = true;
            }

            return result;
        }

        private bool IsValidAirport (Airport airport)
        {
            return airport != null && !string.IsNullOrEmpty(airport.AirportCode) &&
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

        // DELETE
        [HttpDelete]
        [Route("admin-api/flights/{id}")]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, int id)
        {
            FlightStorage.RemoveFlightById(id);
            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
