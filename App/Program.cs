using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cinema_manager_api.Data;
using cinema_manager_api.Models;
using Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cinema_manager_api
{
  public class Program
  {
    public static void Main(string[] args)
    {
      InitializeDatasets();
      CreateHostBuilder(args).Build().Run();
    }

    public static void InitializeDatasets()
    {
      DataPopulator.InitializeSeanses();
      DataPopulator.InitializeReservations();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
