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
        /// Catch any exceptions thrown by the given try action,
        /// call the catch action and the finally action.
        /// </summary>
        /// <param name="try">Try action.</param>
        /// <param name="catch">Catch action.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function,
        /// call the catch action and the finally action.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch action.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function,
        /// call the asynchronous catch function and the finally action.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch function.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function,
        /// call the asynchronous catch function and the asynchronous finally action.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch function.</param>
        /// <param name="finally">Finally function.</param>
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
    }
}
