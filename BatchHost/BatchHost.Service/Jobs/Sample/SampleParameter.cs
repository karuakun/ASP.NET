using System;

namespace BatchHost.Service.Jobs.Sample
{
    public class SampleParameter
    {
        public DateTime EnqueueTime { get; set; }
        public string BatchId { get; set; }
        public string JobId { get; set; }
        public string Parameter { get; set; }
    }
}
