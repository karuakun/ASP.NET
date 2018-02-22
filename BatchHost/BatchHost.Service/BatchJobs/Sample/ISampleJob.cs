namespace BatchHost.BatchInterface.BatchJobs.Sample
{
    public interface ISampleJob
    {
        SampleResponse Execute(SampleParameter param);
    }
}
