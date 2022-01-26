namespace Hw7.Exercise2
{
    /// <summary>
    /// Recurrent job.
    /// </summary>
    public sealed class RecurrentJob : IDisposable
    {
        /// <summary> Running flag. </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Stops job and disposes all resources.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException("Should be implemented by executor");
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
            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
