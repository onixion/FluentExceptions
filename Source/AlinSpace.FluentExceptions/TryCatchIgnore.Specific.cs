using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch-ignore cases with specific exceptions.
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch ignore any exceptions thrown by the given try delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        public static void CatchIgnore<TException>(Action @try) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                @try();
            }
            catch(TException)
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given try delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static TReturn CatchIgnoreReturn<TException, TReturn>(Func<TReturn> @try, TReturn defaultValue = default) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                return @try();
            }
            catch (TException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given asynchronous try delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        public static async Task CatchIgnoreAsync<TException>(Func<Task> @try) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                await @try();
            }
            catch(TException)
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given asynchronous try delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchIgnoreReturnAsync<TException, TReturn>(Func<Task<TReturn>> @try, TReturn defaultValue = default) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                return await @try();
            }
            catch (TException)
            {
                return defaultValue;
            }
        }
    }
}
