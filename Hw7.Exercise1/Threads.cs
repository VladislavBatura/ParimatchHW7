namespace Hw7.Exercise1
{
    /// <summary>
    /// Thread tools.
    /// </summary>
    public static class Threads
    {
        /// <summary>
        /// Creates and starts threads with entry <paramref name="entryPoint"/> point 
        /// for each argument from <paramref name="args"/> collection.
        /// </summary>
        /// <param name="entryPoint">Thread entry point.</param>
        /// <param name="args">Entry point argument.</param>
        /// <returns>
        /// Returns threads collection. 
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Throws when one of the method arguments is <c>null</c>.
        /// </exception>
        public static Thread[] StartAll(ParameterizedThreadStart entryPoint, IEnumerable<object> args)
        {
            if (entryPoint is null || args is null)
            {
                throw entryPoint is null ?
                    new ArgumentNullException(nameof(entryPoint), "Entry poins is null") :
                    new ArgumentNullException(nameof(args), "Arguments is null");
            }

            if (args.Any(a => a is null))
            {
                throw new ArgumentNullException(nameof(args), "One of the argument is null");
            }

            var threads = Enumerable
                .Range(0, args.Count())
                .Select(t => new Thread(entryPoint))
                .ToArray();

            var parameters = args.ToArray();

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i].Start(parameters[i]);
            }

            return threads;
        }

        /// <summary>
        /// Blocks current thread until all <paramref name="threads"/> will be done.
        /// </summary>
        /// <param name="threads">Threads to await.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="threads"/> is <c>null</c>.
        /// </exception>
        public static void WaitAll(IEnumerable<Thread> threads)
        {
            if (threads is null || threads.Any(t => t is null))
            {
                throw new ArgumentNullException(nameof(threads), "Threads is null");
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}
