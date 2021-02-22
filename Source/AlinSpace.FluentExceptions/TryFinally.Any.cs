using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-finally cases. 
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch any exceptions thrown by the given try delegate and call the catch delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static void Finally(Action @try, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                @try();
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static TReturn FinallyReturn<TReturn>(Func<TReturn> @try, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return @try();
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the catch delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task FinallyAsync(Func<Task> @try, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                await @try();
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the catch delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task<TReturn> FinallyReturnAsync<TReturn>(Func<Task<TReturn>> @try, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return await @try();
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the asynchronous catch delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task FinallyAsync(Func<Task> @try, Func<Task> @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                await @try();
            }
            finally
            {
                await @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate and call the asynchronous catch delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task<TReturn> FinallyReturnAsync<TReturn>(Func<Task<TReturn>> @try, Func<Task> @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return await @try();
            }
            finally
            {
                await @finally();
            }
        }
    }
}
