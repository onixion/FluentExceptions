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
        /// Catch specific exceptions thrown by the given try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
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
        /// Catch specific exceptions thrown by the given try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static TReturn CatchReturn<TException, TReturn>(Func<TReturn> @try, Action<TException> @catch, TReturn defaultValue = default) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                return @try();
            }
            catch (TException e)
            {
                @catch(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
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
        /// Catch specific exceptions thrown by the given asynchronous try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchReturnAsync<TException, TReturn>(Func<Task<TReturn>> @try, Action<TException> @catch, TReturn defaultValue = default) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                return await @try();
            }
            catch (TException e)
            {
                @catch(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try delegate and call the asynchronous catch delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
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

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try delegate and call the asynchronous catch delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchReturnAsync<TException, TReturn>(Func<Task<TReturn>> @try, Func<TException, Task> @catch, TReturn defaultValue = default) where TException : Exception
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                return await @try();
            }
            catch (TException e)
            {
                await @catch(e);
                return defaultValue;
            }
        }
    }
}
