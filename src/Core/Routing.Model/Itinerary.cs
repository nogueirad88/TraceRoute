using System.Collections.Generic;
using System.Linq;

namespace Routing.Model
{
    public class Itinerary
    {
        public List<Route> Routes { get; set; }

        public Itinerary() {
            Routes = new List<Route>();
        }

        public override string ToString()
        {
            var fullName = string.Join(" - ", Routes.Select(p => p.From));

            return fullName + " - " + Routes.LastOrDefault()?.To;
        }
    }
}
