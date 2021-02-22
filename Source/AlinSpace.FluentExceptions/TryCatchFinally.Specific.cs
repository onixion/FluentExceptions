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
        /// Catch specific exceptions thrown by the given try action,
        /// call the catch action and the finally action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try action.</param>
        /// <param name="catch">Catch action.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch specific exceptions thrown by the given asynchronous try function,
        /// call the catch action and the finally action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch action.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch specific exceptions thrown by the given asynchronous try function,
        /// call the asynchronous catch function and the finally action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch function.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function,
        /// call the asynchronous catch function and the asynchronous finally action.
        /// </summary>
        /// <typeparam name="TException">Type of exception to catch.</typeparam>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch function.</param>
        /// <param name="finally">Finally function.</param>
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
    }
}
