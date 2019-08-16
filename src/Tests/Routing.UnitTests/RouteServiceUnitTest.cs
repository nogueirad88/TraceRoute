using Moq;
using Routing.Business;
using Routing.Model;
using Routing.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Routing.Repository.Interfaces;
using Routing.Service;
using Xunit;

namespace Routing.UnitTests
{
    public class RouteServiceUnitTest
    {
        [Fact]
        public void GetRoutesFromFile_ShouldReturn_CorrectParsedDictionary()
        {
            var fileMock = new List<string>
            {
                "GRU,BRC,10",
                "BRC,SCL,5 ",
                "GRU,CDG,75",
                "GRU,SCL,20",
                "GRU,ORL,56",
                "ORL,CDG,5 ",
                "SCL,ORL,20",
            };

            var fileRepositoryMock = new Mock<IFileRepository>();

            fileRepositoryMock.Setup(m => m.ReadCsv()).Returns(fileMock);

            var routeService = new RouteService(fileRepositoryMock.Object);

            var routesDic = routeService.GetRoutesFromFile();

            Assert.Equal(4, routesDic["GRU"].Count);
            Assert.Contains(routesDic["GRU"].First().ToString(), fileMock);
        }

        [Fact]
        public void Save_ShouldReturn_CorrectParsedRoute()
        {
            var routeToSave = new Route() { From = "SCL", To = "ORL", Cost = 20 };

            var fileRepositoryMock = new Mock<IFileRepository>();

            fileRepositoryMock.Setup(m => m.SaveLine(routeToSave.ToString())).Returns(routeToSave.ToString());

            var routeService = new RouteService(fileRepositoryMock.Object);

            var savedRoute = routeService.Save(routeToSave);

            Assert.NotSame(routeToSave, savedRoute);
            Assert.Equal(routeToSave.From, savedRoute.From);
            Assert.Equal(routeToSave.To, savedRoute.To);
            Assert.Equal(routeToSave.Cost, savedRoute.Cost);
        }
    }
}
