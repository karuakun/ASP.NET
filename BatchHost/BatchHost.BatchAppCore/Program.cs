using System;
using Hangfire;
using Hangfire.Redis;

namespace BatchHost.BatchAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseRedisStorage("localhost:6379", new RedisStorageOptions
            {
                Prefix = "WebApi:BatchStorage:"
            });
            using (var server = new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
