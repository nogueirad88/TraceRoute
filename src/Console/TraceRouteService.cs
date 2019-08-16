using Routing.Business.Interfaces;
using Routing.TraceRoute.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Routing.TraceRoute
{
    public class TraceRouteService : ITraceRouteService
    {
        private readonly IRouteBusiness _routeBusiness;
        private readonly IQuestionBusiness _questionBusiness;

        public TraceRouteService(IRouteBusiness routeBusiness, IQuestionBusiness questionBusiness )
        {
            _routeBusiness = routeBusiness;
            _questionBusiness = questionBusiness;
        }

        public void Start()
        {
            while (true)
            {
                var userInput = _questionBusiness.AskLocation();

                if (IsExit(userInput))
                    return;

                if (IsValidUserInput(userInput))
                {
                    var routes = userInput.Split("-");
                    var bestRoute = _routeBusiness.GetBestRoute(routes[0], routes[1]);
                    Console.WriteLine(bestRoute == null
                        ? "Route not found"
                        : $"Best Route: {bestRoute} >> {bestRoute.Routes.Sum(p => p.Cost)} ");
                }
                else
                {
                    Console.WriteLine("please use a correct format, ex: UFG-HGT");
                    continue;
                }
            }
        }

        private static bool IsExit(string userInput)
        {
            return string.IsNullOrEmpty(userInput);
        }

        public bool IsValidUserInput(string locationConsole)
        {
            var regex = new Regex(@"[A-z]{3}-[A-z]{3}$", RegexOptions.IgnoreCase);

            return regex.IsMatch(locationConsole);
        }
    }
}
