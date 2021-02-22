using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch-finally cases with specific exceptions.
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch specific exceptions thrown by the given try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static void CatchFinally<TException>(
            Action @try, 
            Action<TException> @catch, 
            Action @finally) 
            where TException : Exception
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
            catch (TException e)
            {
                @catch(e);
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static TReturn CatchFinallyReturn<TException, TReturn>(
            Func<TReturn> @try,
            Action<TException> @catch,
            Action @finally,
            TReturn defaultValue = default)
            where TException : Exception
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
            catch (TException e)
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
        /// Catch specific exceptions thrown by the given asynchronous try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task CatchFinallyAsync<TException>(
            Func<Task> @try, 
            Action<TException> @catch, 
            Action @finally)
            where TException : Exception
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
            catch (TException e)
            {
                @catch(e);
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try delegate,
        /// call the catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchFinallyReturnAsync<TException, TReturn>(
            Func<Task<TReturn>> @try,
            Action<TException> @catch,
            Action @finally,
            TReturn defaultValue = default)
            where TException : Exception
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
            catch (TException e)
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
        /// Catch specific exceptions thrown by the given asynchronous try delegate,
        /// call the asynchronous catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task CatchFinallyAsync<TException>(
            Func<Task> @try,
            Func<TException, Task> @catch, 
            Action @finally)
            where TException : Exception
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
            catch (TException e)
            {
                await @catch(e);
            }
            finally
            {
                @finally();
            }
        }

        /// <summary>
        /// Catch specific exceptions thrown by the given asynchronous try delegate,
        /// call the asynchronous catch delegate and the finally delegate.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchFinallyReturnAsync<TException, TReturn>(
            Func<Task<TReturn>> @try,
            Func<TException, Task> @catch,
            Action @finally,
            TReturn defaultValue = default)
            where TException : Exception
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
            catch (TException e)
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
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        public static async Task CatchFinallyAsync<TException>(
            Func<Task> @try, 
            Func<TException, Task> @catch, 
            Func<Task> @finally)
            where TException : Exception
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
            catch (TException e)
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
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <typeparam name="TReturn">Type of the return value.</typeparam>
        /// <param name="try">Try delegate.</param>
        /// <param name="catch">Catch delegate.</param>
        /// <param name="finally">Finally delegate.</param>
        /// <param name="defaultValue">Default value.</param>
        public static async Task<TReturn> CatchFinallyReturnAsync<TException, TReturn>(
            Func<Task<TReturn>> @try,
            Func<TException, Task> @catch,
            Func<Task> @finally,
            TReturn defaultValue = default)
            where TException : Exception
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
            catch (TException e)
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
