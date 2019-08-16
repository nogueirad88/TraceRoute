using Routing.Business.Interfaces;
using Routing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Routing.Service.Interfaces;

namespace Routing.Business
{
    public class RouteBusiness : IRouteBusiness
    {
        private readonly IRouteService _routeService;
        private Dictionary<string, List<Route>> _routeDic;

        public RouteBusiness(IRouteService routeService)
        {
            _routeService = routeService;
        }

        public Itinerary GetBestRoute(string fromRoute, string toRoute)
        {
            _routeDic = _routeService.GetRoutesFromFile();

            var itineraries = new List<Itinerary>();

            foreach (var route in _routeDic[fromRoute])
            {
                DeepFind(new Itinerary(), route, toRoute, itineraries);
            }

            return itineraries.OrderBy(p => p.Routes.Sum(x => x.Cost)).FirstOrDefault();
        }

        private void DeepFind(Itinerary itinerary, Route from, string to, ICollection<Itinerary> itineraries)
        {
            var activeItinerary = new Itinerary();

            activeItinerary.Routes.AddRange(itinerary.Routes);

            if (IsReturningRoute(activeItinerary, from))
                return;

            activeItinerary.Routes.Add(from);

            if (from.To == to)
            {
                itineraries.Add(activeItinerary);
                return;
            }

            if (!NextLocationHasRoute(from))
                return;

            foreach (var route in _routeDic[from.To])
            {
                DeepFind(activeItinerary, route, to, itineraries);
            }
        }

        private bool NextLocationHasRoute(Route from)
        {
            return _routeDic.ContainsKey(from.To);
        }

        private static bool IsReturningRoute(Itinerary itinerary, Route from)
        {
            return itinerary.Routes.Exists(p => p.From == from.To);
        }
    }
}
