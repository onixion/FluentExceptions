using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch-ignore cases. 
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch ignore any exceptions thrown by the given try delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        public static void CatchIgnore(Action @try)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                @try();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given try delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static TReturn CatchIgnoreReturn<TReturn>(Func<TReturn> @try, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                return @try();
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given asynchronous try delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        public static async Task CatchIgnoreAsync(Func<Task> @try)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                await @try();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given asynchronous try delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchIgnoreReturnAsync<TReturn>(Func<Task<TReturn>> @try, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                return await @try();
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
