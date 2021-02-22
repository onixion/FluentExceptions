using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch-finally cases. 
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch any exceptions thrown by the given try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static void CatchFinally(Action @try, Action<Exception> @catch, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                @try();
            }
            catch(Exception e)
            {
                @catch(e);
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static TReturn CatchFinallyReturn<TReturn>(Func<TReturn> @try, Action<Exception> @catch, Action @finally, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return @try();
            }
            catch (Exception e)
            {
                @catch(e);
                return defaultValue;
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task CatchFinallyAsync(Func<Task> @try, Action<Exception> @catch, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                await @try();
            }
            catch (Exception e)
            {
                @catch(e);
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchFinallyReturnAsync<TReturn>(Func<Task<TReturn>> @try, Action<Exception> @catch, Action @finally, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return await @try();
            }
            catch (Exception e)
            {
                @catch(e);
                return defaultValue;
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate,
        /// call the asynchronous catch delegate and the finally delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task CatchFinallyAsync(Func<Task> @try, Func<Exception, Task> @catch, Action @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                await @try();
            }
            catch (Exception e)
            {
                await @catch(e);
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate,
        /// call the asynchronous catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchFinallyReturnAsync<TReturn>(Func<Task<TReturn>> @try, Func<Exception, Task> @catch, Action @finally, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return await @try();
            }
            catch (Exception e)
            {
                await @catch(e);
                return defaultValue;
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate,
        /// call the asynchronous catch delegate and the asynchronous finally delegate.
        /// </summary>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task CatchFinallyAsync(Func<Task> @try, Func<Exception, Task> @catch, Func<Task> @finally)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                await @try();
            }
            catch (Exception e)
            {
                await @catch(e);
            }
            finally
            {
                await @finally();
            }
        }

        /// <summary>
        /// Catch any exceptions thrown by the given asynchronous try delegate,
        /// call the asynchronous catch delegate and the asynchronous finally delegate.
        /// </summary>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchFinallyReturnAsync<TReturn>(Func<Task<TReturn>> @try, Func<Exception, Task> @catch, Func<Task> @finally, TReturn defaultValue = default)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            if (@catch == null)
                throw new ArgumentNullException(nameof(@catch));

            if (@finally == null)
                throw new ArgumentNullException(nameof(@finally));

            try
            {
                return await @try();
            }
            catch (Exception e)
            {
                await @catch(e);
                return defaultValue;
            }
            finally
            {
                await @finally();
            }
        }
    }
}
