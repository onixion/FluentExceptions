using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Methods for handling try-catch-ignore cases. 
    /// </summary>
    public static partial class Try
    {
        /// <summary>
        /// Catch ignore any exceptions thrown by the given try action.
        /// </summary>
        /// <param name="try">Try action.</param>
        public static void CatchIgnore(Action @try)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                @try();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore any exceptions thrown by the given asynchronous try function.
        /// </summary>
        /// <param name="try">Try function.</param>
        public static async Task CatchIgnoreAsync(Func<Task> @try)
        {
            if (@try == null)
                throw new ArgumentNullException(nameof(@try));

            try
            {
                await @try();
            }
            catch
            {
                // ignore
            }
        }
    }
}
