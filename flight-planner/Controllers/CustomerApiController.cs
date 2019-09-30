using flight_planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flight_planner.Controllers
{
    public class CustomerApiController : ApiController
    {
        /*// GET: api/CustomerApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CustomerApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CustomerApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerApi/5
        public void Delete(int id)
        {
        }*/

        /*[HttpGet]
        [Route("api/airports")]*/

        /*[HttpPost]
        [Route("api/flights/search")]

        public FlighSearchResult FlightSearch(FlightSearchRequest search)
        {
            var result = FlightStorage.GetFligths();
            var matchedItems = result.Where(f.From.Airport == search.From &&
                                            f.To.Airport == search.To &&
                                            f.DepartureTime == search.DepartureDate).ToList();
            var response = new FlightSearchResult
            {

            }
        }*/

        

    }
}
