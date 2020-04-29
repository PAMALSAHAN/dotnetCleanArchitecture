using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Infras
namespace InvoiceManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host=CreateWebHostBuilder(args).Build();
            using(var scope=host.Services.CreateScope()){
                var services=scope.ServiceProvider;
                try
                {
                    var context=services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                }
                catch (System.Exception ex)
                {
                    var logger=services.GetRequiredService<ILogger<Program>>();
                    logger.Logerror(ex,"error in the databae");

                    throw;
                }
            }
            host.run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        
    }
}
