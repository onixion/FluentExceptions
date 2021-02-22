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
        /// Catch any exceptions thrown by the given try action and call the catch action.
        /// </summary>
        /// <param name="try">Try action.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function and call the catch action.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="finally">Finally action.</param>
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
        /// Catch any exceptions thrown by the given asynchronous try function and call the asynchronous catch function.
        /// </summary>
        /// <param name="try">Try function.</param>
        /// <param name="finally">Finally function.</param>
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
    }
}
