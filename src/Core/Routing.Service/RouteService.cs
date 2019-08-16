using Routing.Service.Interfaces;
using Routing.Model;
using System.Collections.Generic;
using System.Linq;
using Routing.Repository.Interfaces;

namespace Routing.Service
{
    public class RouteService : IRouteService {

        public readonly IFileRepository _fileRepository;

        public RouteService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Dictionary<string,List<Route>> GetRoutesFromFile()
        {
            var csv = _fileRepository.ReadCsv();

            var routes = csv.Select(ParseRoute).ToList();

            return routes.Select(p => p.From)
                .Distinct()
                .ToDictionary(route => route, route => routes.FindAll(p => p.From == route));
        }

        public Route Save(Route route)
        {
            var savedLine = _fileRepository.SaveLine(route.ToString());

            return ParseRoute(savedLine);
        }

        private static Route ParseRoute(string line)
        {
            var values = line.Split(",");

            var route = new Route()
            {
                From = values[0],
                To = values[1],
                Cost = int.Parse(values[2])
            };

            return route;
        }
    }
}
