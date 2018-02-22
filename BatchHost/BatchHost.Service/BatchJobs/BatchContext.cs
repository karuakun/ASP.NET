using System;
using System.Collections.Generic;
using System.Text;

namespace BatchHost.BatchInterface.BatchJobs
{
    public class BatchContext
    {
        public string UserId { get; set; }
        public string BatchJobId { get; set; }
        public DateTime EnqueueDate { get; set; }
    }
}
