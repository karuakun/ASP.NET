using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hangfire.Annotations;

namespace BatchHost.BatchInterface
{
    public class BackgroundJob
    {
        public static string Enqueue<T>([InstantHandle] [NotNull] Expression<Func<T, Task>> methodCall)
        {
            return Hangfire.BackgroundJob.Enqueue<T>(methodCall);
        }

        public static string Enqueue<T>([InstantHandle] [NotNull] Expression<Action<T>> methodCall)
        {
            return Hangfire.BackgroundJob.Enqueue(methodCall);
        }

        public static string Enqueue([InstantHandle] [NotNull] Expression<Func<Task>> methodCall)
        {
            return Hangfire.BackgroundJob.Enqueue(methodCall);
        }
        public static string Enqueue([InstantHandle] [NotNull] Expression<Action> methodCall)
        {
            return Hangfire.BackgroundJob.Enqueue(methodCall);
        }
    }
}
