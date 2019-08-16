using Routing.Model;
using System.Collections.Generic;

namespace Routing.Service.Interfaces
{
    public interface IRouteService{
        Dictionary<string, List<Route>> GetRoutesFromFile();
    }
}
