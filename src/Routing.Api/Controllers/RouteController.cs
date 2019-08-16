using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Routing.Api.RequestObjects;
using Routing.Api.ResponseObjects;
using Routing.Business.Interfaces;
using Routing.Model;

namespace Routing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteBusiness _routeBusiness;

        public RouteController(IRouteBusiness routeBusiness)
        {
            _routeBusiness = routeBusiness;
        }

        // GET api/route?from=GRU&to=CDG
        [HttpGet]
        public ActionResult Get([FromQuery]string from, [FromQuery] string to)
        {
            var itinerary = _routeBusiness.GetBestRoute(from, to);

            if (itinerary == null)
                return NotFound("Route Not Found");

            var response = new RouteResponse(itinerary);

            return Ok(response);
        }

        // POST api/route
        [HttpPost]
        public ActionResult Post([FromBody] RouteRequest routeRequest)
        {
            var route = new Route
            {
                From = routeRequest.From,
                To = routeRequest.To,
                Cost = routeRequest.Cost.Value
            };

            var savedRoute = _routeBusiness.SaveRoute(route);

            return Created("", savedRoute);
        }
    }
}
