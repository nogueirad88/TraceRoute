using System;
using System.Collections.Generic;
using System.Text;
using Routing.Model;

namespace Routing.Business.Interfaces
{
    public interface IRouteBusiness
    {
        Itinerary GetBestRoute(string fromRoute, string toRoute);
    }
}
