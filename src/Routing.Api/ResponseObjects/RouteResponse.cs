using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Routing.Model;

namespace Routing.Api.ResponseObjects
{
    public class RouteResponse
    {
        public string Route { get; set; }
        public double Price { get; set; }

        public RouteResponse(Itinerary itinerary)
        {
            Route = itinerary.ToString();
            Price = itinerary.Routes.Sum(p => p.Cost);
        }
    }
}
