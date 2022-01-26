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
            throw new NotImplementedException("Should be implemented by executor");
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
            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
