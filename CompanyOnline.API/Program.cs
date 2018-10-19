using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CompanyOnline.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // CreateWebHostBuilder(args).Build().Run();
            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .ConfigureLogging((hostingContext, logging) =>
            {
                // The ILoggingBuilder minimum level determines the
                // the lowest possible level for logging. The log4net
                // level then sets the level that we actually log at.
                logging.AddLog4Net();
                logging.SetMinimumLevel(LogLevel.Error);
                logging.AddDebug();
                logging.AddConsole();
            })
            // .UseApplicationInsights()
            .Build();

        host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
