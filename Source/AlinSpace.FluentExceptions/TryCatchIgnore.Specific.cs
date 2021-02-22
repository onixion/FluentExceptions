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
        /// Catch ignore any exceptions thrown by the given try action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try action.</param>
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
        /// Catch ignore any exceptions thrown by the given asynchronous try function.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try function.</param>
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
    }
}
