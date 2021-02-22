using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch cases for specific exceptions.
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch specific exceptions thrown by the given try action and call the catch action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try action.</param>
        /// <param name="catch">Catch action.</param>
        public static void Catch<TException>(Action @try, Action<TException> @catch) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                @try();
            }
            catch (TException e)
            {
                @catch(e);
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try function and call the catch action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch action.</param>
        public static async Task CatchAsync<TException>(Func<Task> @try, Action<TException> @catch) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                await @try();
            }
            catch (TException e)
            {
                @catch(e);
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try function and call the asynchronous catch function.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch function.</param>
        public static async Task CatchAsync<TException>(Func<Task> @try, Func<TException, Task> @catch) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                await @try();
            }
            catch (TException e)
            {
                await @catch(e);
            }
        }
    }
}
