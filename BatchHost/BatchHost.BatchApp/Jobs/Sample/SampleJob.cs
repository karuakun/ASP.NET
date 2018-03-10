using System;
using BatchHost.BatchApp.Services;
using BatchHost.BatchInterface.BatchJobs.Sample;

namespace BatchHost.BatchApp.Jobs.Sample
{
    public class SampleJob : BatchJobBase<SampleParameter, SampleResponse>, ISampleJob
    {
        private ISampleService SampleService { get; set; }
        public SampleJob(IUserContext userContext, ISampleService sampleService) 
            : base(userContext)
        {
            SampleService = sampleService;
        }

        public override SampleResponse OnExecute(SampleParameter param)
        {
            return new SampleResponse
            {
                EndTime = new DateTime(),
                Message = "Hoge"
            };
        }
    }
}
