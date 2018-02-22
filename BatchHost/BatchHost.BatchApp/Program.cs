using System;
using Autofac;
using BatchHost.BatchApp.Jobs.Sample;
using BatchHost.BatchApp.Services;
using Hangfire;
using Hangfire.Redis;
using Serilog;

namespace BatchHost.BatchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureLogger();
            ConfigureBatchStorage();
            ConfigureBatchActivator();

            RunBatchServer();
        }

        private static void RunBatchServer()
        {
            using (new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void ConfigureBatchStorage()
        {
            GlobalConfiguration.Configuration.UseRedisStorage("localhost:6379", new RedisStorageOptions
            {
                Prefix = "WebApi:BatchStorage:"
            });
        }

        private static void ConfigureBatchActivator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserContext>().AsImplementedInterfaces();


            builder.RegisterType<SampleService>().AsImplementedInterfaces();


            builder.RegisterType<SampleJob>().AsImplementedInterfaces();

            GlobalConfiguration.Configuration.UseAutofacActivator(builder.Build());
        }

        private static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("servicelog.txt")
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
