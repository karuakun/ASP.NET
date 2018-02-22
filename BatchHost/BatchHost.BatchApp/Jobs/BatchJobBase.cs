using System;
using BatchHost.BatchApp.Services;
using BatchHost.BatchInterface.BatchJobs;
using Serilog;

namespace BatchHost.BatchApp.Jobs
{
    public abstract class BatchJobBase<TParameter, TResponse>
        where TParameter: BatchJobParameter
        where TResponse : BatchJobResponse
    {
        protected IUserContext UserContext { get; set; }

        protected BatchJobBase(IUserContext userContext)
        {
            UserContext = userContext;
        }

        public virtual TResponse Execute(TParameter param)
        {
            try
            {
                Log.Logger.Information($"START:{DateTime.Now:yyyy-MM-dd hh:mm:ss.fff}");
                return OnExecute(param);
            }
            finally 
            {
                Log.Logger.Information($"END:{DateTime.Now:yyyy-MM-dd hh:mm:ss.fff}");
            }
        }

        public abstract TResponse OnExecute(TParameter param);
    }
}
