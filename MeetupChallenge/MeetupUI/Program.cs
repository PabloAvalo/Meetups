using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLogic.APIManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MeetupUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            APIHelper.InitializeApiClient();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
