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
        /// Catch any exceptions thrown by the given try action and call the catch action.
        /// </summary>
        /// <param name="try">Try action.</param>
        /// <param name="catch">Catch action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function and call the catch function.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function and call the asynchronous catch function.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="catch">Catch function.</param>
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
    }
}
