namespace BatchHost.BatchApp.Services
{
    public class SampleService: ISampleService
    {
        public IUserContext UserContext;

        public SampleService(IUserContext userContext)
        {
            UserContext = userContext;
        }
    }
}
