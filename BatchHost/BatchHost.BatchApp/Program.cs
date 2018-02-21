using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Redis;
using Serilog;

namespace BatchHost.BatchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("log.txt")
                .WriteTo.Console()
                .CreateLogger();

            GlobalConfiguration.Configuration.UseRedisStorage("localhost:6379", new RedisStorageOptions
            {
                Prefix = "WebApi:BatchStorage:"
            });
            using (var server = new BackgroundJobServer(new BackgroundJobServerOptions
            {
            }))
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class CustomBackgroundJobServer : BackgroundJobServer
    {
        
    }
}
