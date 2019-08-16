using Microsoft.Extensions.DependencyInjection;
using Routing.Business;
using Routing.Business.Interfaces;
using Routing.Repository.Interfaces;
using Routing.Service;
using Routing.Service.Interfaces;
using Routing.TraceRoute.Interfaces;
using System;
using System.IO;
using Routing.Repository;

namespace Routing.TraceRoute
{
    public class Program
    {
        private static string _filePath;

        public static void Main(string[] args)
        {
            //if (!File.Exists(args[0]))
            //{
            //    Console.WriteLine("CSV File Not Found");
            //    return;
            //}

            //_filePath = args[0];

            _filePath = @"C:\Users\Douglas\Desktop\Routing\src\Console\file.csv";

            var serviceProvider = SetupDependencyInjection();

            var traceRouteService = serviceProvider.GetService<ITraceRouteService>();

            traceRouteService.Start();
        }

        private static ServiceProvider SetupDependencyInjection()
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ITraceRouteService, TraceRouteService>()
            .AddSingleton<IRouteBusiness, RouteBusiness>()
            .AddSingleton<IQuestionBusiness, QuestionBusiness>()
            .AddSingleton<IRouteService, RouteService>()
            .AddSingleton<IFileRepository>(s => new FileRepository(_filePath))
            .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
