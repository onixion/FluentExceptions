using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch cases. 
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch any exceptions thrown by the given try delegate and call the catch delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        public static void Catch(Action @try, Action<Exception> @catch)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                @try();
            }
            catch (Exception e)
            {
                @catch(e);
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static TReturn CatchReturn<TReturn>(Func<TReturn> @try, Action<Exception> @catch, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                return @try();
            }
            catch (Exception e)
            {
                @catch(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the catch delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        public static async Task CatchAsync(Func<Task> @try, Action<Exception> @catch)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                await @try();
            }
            catch (Exception e)
            {
                @catch(e);
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchReturnAsync<TReturn>(Func<Task<TReturn>> @try, Action<Exception> @catch, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            try
            {
                return await @try();
            }
            catch (Exception e)
            {
                @catch(e);
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the asynchronous catch delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        public static async Task CatchAsync(Func<Task> @try, Func<Exception, Task> @catch)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                await @try();
            }
            catch (Exception e)
            {
                await @catch(e);
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the asynchronous catch delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchReturnAsync<TReturn>(Func<Task<TReturn>> @try, Func<Exception, Task> @catch, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                return await @try();
            }
            catch (Exception e)
            {
                await @catch(e);
                return defaultValue;
            }
        }
    }
}
