namespace Hw7.Exercise2
{
    /// <summary>
    /// Recurrent job.
    /// </summary>
    public sealed class RecurrentJob : IDisposable
    {
        /// <summary> Running flag. </summary>
        public bool IsRunning { get; private set; }

        private int Times { get; }
        private int Count { get; set; }
        private Action<int, object?> Action { get; set; }
        private object? Context { get; }
        private Timer? timer { get; set; }

        private RecurrentJob(int times, Action<int, object?> action, object? context)
        {
            Times = times;
            Action = action;
            IsRunning = true;
            Context = context;
            Count = 0;
        }

        /// <summary>
        /// Stops job and disposes all resources.
        /// </summary>
        public void Dispose()
        {
            IsRunning = false;
            timer!.Dispose();
        }

        /// <summary>
        /// Starts new recurrent job.
        /// </summary>
        /// <param name="dueTime">Delay before first job execution.</param>
        /// <param name="interval">Delay between job executions.</param>
        /// <param name="times">Job executions count.</param>
        /// <param name="job">Job.</param>
        /// <param name="context">Optional context.</param>
        /// <returns>Retruns new started job.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when one of the required arguments 
        /// (<paramref name="dueTime"/>, <paramref name="interval"/>, <paramref name="times"/>)
        /// is negative
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when job is <c>null</c>.
        /// </exception>
        public static RecurrentJob Run(TimeSpan dueTime, TimeSpan interval, int times, Action<int, object?> job, object? context)
        {
            if (dueTime < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(dueTime), "Delay is below zero");
            }
            else if (interval < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(interval), "Interval is below zero");
            }
            else if (times < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(times), "Executions count below zero");
            }
            else if (job is null)
            {
                throw new ArgumentNullException(nameof(job), "Job is null");
            }

            var o = new RecurrentJob(times, job, context);

            var timer = new Timer(Callback!, o, dueTime, interval);

            o.timer = timer;
            return o;
        }

        private static void Callback(object state)
        {
            var job = state as RecurrentJob;
            if (job!.Count == job.Times || !job.IsRunning)
            {
                job.Dispose();
            }
            job!.Action.Invoke(job.Count, job.Context);
            job.Count++;
        }
    }
}
