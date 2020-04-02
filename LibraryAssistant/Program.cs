using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAssistant.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryAssistant
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
           var host =  CreateHostBuilder(args).Build();

            using (var ScopeService = host.Services.CreateScope())
            {
                var dbContext = ScopeService.ServiceProvider.GetRequiredService<LibraryAssistantDbContext>();
                await dbContext.Database.MigrateAsync();
                
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
