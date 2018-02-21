using System;
using System.Threading;
using Serilog;

namespace BatchHost.Service.Jobs.Sample
{
    public class SampleJob
    {
        public SampleResponse Execute(SampleParameter param)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("servicelog.txt")
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information($"Enqueue:{param.EnqueueTime}");
            Log.Logger.Information($"Start:{DateTime.Now}");
            Thread.Sleep(10 * 1000);
            Log.Logger.Information($"End:{DateTime.Now}");

            return new SampleResponse
            {
                EndTime = new DateTime(),
                Message = "Hoge"
            };
        }
    }
}
