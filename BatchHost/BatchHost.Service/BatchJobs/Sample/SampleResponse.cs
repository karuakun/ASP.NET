using System;

namespace BatchHost.BatchInterface.BatchJobs.Sample
{
    public class SampleResponse: BatchJobResponse
    {
        public DateTime EndTime { get; set; }
        public string Message { get; set; }
    }
}
