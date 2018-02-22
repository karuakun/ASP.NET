using System.Threading.Tasks;
using BatchHost.BatchInterface.BatchJobs;
using Hangfire;
using Hangfire.Common;
using Hangfire.States;

namespace BatchHost.BatchInterface
{
    public class BatchJobMonitor
    {
        public BatchJobMonitorConfig Config { get; set; }
        public BatchJobMonitor()
        {
            Config = new BatchJobMonitorConfig();
        }

        public BatchJobMonitor(BatchJobMonitorConfig config)
        {
            Config = config;
        }

        public async Task<TResponse> WaitForExit<TResponse>(string jobId)
            where TResponse : BatchJobResponse
        {
            var conn = JobStorage.Current.GetConnection();
            for (var i = 0; i < Config.RetryCount; i++)
            {
                await Task.Delay(Config.WatchInterval);
                var jobData = conn.GetJobData(jobId);
                if (jobData.State == SucceededState.StateName)
                {
                    var stateData = conn.GetStateData(jobId);
                    return JobHelper.FromJson<TResponse>(stateData.Data["Result"]);
                }

                if (jobData.State == FailedState.StateName)
                {

                }
            }
            throw new BatchJobWaitTimeoutException();
        }
    }
}
