using flight_planner.Atribute;
using flight_planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace flight_planner.Controllers
{
    public class TestingApiController : ApiController
    {
        [HttpPost]
        [Route("testing-api/clear")]
        public bool Clear()
        {
            FlightStorage.ClearList();
            return true;
        }
    }
}
