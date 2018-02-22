namespace BatchHost.BatchInterface
{
    public class BatchJobMonitorConfig
    {
        public int WatchInterval { get; set; } = 500;
        public int RetryCount { get; set; } = 50;
    }
}
