using Moq;
using Routing.Business;
using Routing.Model;
using Routing.Service.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Routing.UnitTests
{
    public class RouteBusinessUnitTest
    {
        [Fact]
        public void GetBestRoute_ShouldReturn_CheapestRoute()
        {
            var routesMock = new Dictionary<string, List<Route>>();

            routesMock.Add("GRU", new List<Route> {
                new Route() { From = "GRU", To = "BRC", Cost = 10 },
                new Route() { From = "GRU", To = "CDG", Cost = 75 },
                new Route() { From = "GRU", To = "SCL", Cost = 20 },
                new Route() { From = "GRU", To = "ORL", Cost = 56 }
            });

            routesMock.Add("BRC", new List<Route> {
                new Route() { From = "BRC", To = "SCL", Cost = 5 }
            });

            routesMock.Add("ORL", new List<Route> {
                new Route() { From = "ORL", To = "CDG", Cost = 5 }
            });

            routesMock.Add("SCL", new List<Route> {
                new Route() { From = "SCL", To = "ORL", Cost = 20 }
            });
        
            var routeServiceMock = new Mock<IRouteService>();

            routeServiceMock.Setup(m => m.GetRoutesFromFile()).Returns(routesMock);

            var routeBusiness = new RouteBusiness(routeServiceMock.Object);

            var cheapestRoute = routeBusiness.GetBestRoute("GRU","CDG");

            Assert.Equal("GRU - BRC - SCL - ORL - CDG", cheapestRoute.ToString());
        }

        [Fact]
        public void Save_ShouldCall_RouteService_Save()
        {
            var routeServiceMock = new Mock<IRouteService>();

            var routeToSave = new Route() {From = "SCL", To = "ORL", Cost = 20};

            Route routePassed = null;

            routeServiceMock.Setup(m => m.Save(It.IsAny<Route>())).Returns(routeToSave)
                                                                               .Callback<Route>(p => routePassed = p);

            var routeBusiness = new RouteBusiness(routeServiceMock.Object);

            routeBusiness.SaveRoute(routeToSave);

            Assert.Equal(routeToSave, routePassed);
        }
    }
}
