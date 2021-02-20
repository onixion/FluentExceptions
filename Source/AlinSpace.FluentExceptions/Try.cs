using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions
{
    /// <summary>
    /// Try.
    /// </summary>
    public static class Try
    {
        /// <summary>
        /// Catch ignore exception thrown by the given action.
        /// </summary>
        /// <param name="action">Action.</param>
        public static void CatchIgnore(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch ignore exception thrown by the given async action.
        /// </summary>
        /// <param name="action">Action.</param>
        public static async Task CatchIgnoreAsync(Func<Task> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Catch exception from action and call finally action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="finallyAction">Finally action.</param>
        public static void Finally(Action action, Action finallyAction = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            finally
            {
                finallyAction?.Invoke();
            }
        }

        /// <summary>
        /// Catch exception from action and call finally action.
        /// </summary>
        /// <param name="action">Action async.</param>
        /// <param name="finallyAction">Finally action.</param>
        public static async Task FinallyAsync(Func<Task> action, Action finallyAction = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            finally
            {
                finallyAction?.Invoke();
            }
        }

        /// <summary>
        /// Catch exception from action and call finally action.
        /// </summary>
        /// <param name="action">Action async.</param>
        /// <param name="finallyAction">Finally action async.</param>
        public static async Task FinallyAsync(Func<Task> action, Func<Task> finallyAction = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            finally
            {
                await finallyAction?.Invoke();
            }
        }

        /// <summary>
        /// Catch exception from action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static void Catch(Action action, Action<Exception> exception = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            catch (Exception e)
            {
                exception?.Invoke(e);
            }
        }

        /// <summary>
        /// Catch exception from action asynchronously.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync(Func<Task> action, Action<Exception> exception = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            catch (Exception e)
            {
                exception?.Invoke(e);
            }
        }

        /// <summary>
        /// Catch exception from action asynchronously.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync(Func<Task> action, Func<Exception, Task> exception = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            catch (Exception e)
            {
                await exception?.Invoke(e);
            }
        }

        /// <summary>
        /// Catch specific exception.
        /// </summary>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static void Catch<TException>(Action action, Action<TException> exception = null) where TException : Exception
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                action();
            }
            catch (TException e)
            {
                exception?.Invoke(e);
            }
        }

        /// <summary>
        /// Catch specific exception asynchronously.
        /// </summary>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync<TException>(Func<Task> action, Action<TException> exception = null) where TException : Exception
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            catch (TException e)
            {
                exception?.Invoke(e);
            }
        }

        /// <summary>
        /// Catch specific exception asynchronously.
        /// </summary>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="exception">Exception.</param>
        public static async Task CatchAsync<TException>(Func<Task> action, Func<TException, Task> exception) where TException : Exception
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                await action();
            }
            catch (TException e)
            {
                await exception?.Invoke(e);
            }
        }

        /// <summary>
        /// Catch ignore any exception and set value default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">Action.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value or default value.</returns>
        public static T CatchIgnore<T>(Func<T> action, T defaultValue = default(T))
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                return action();
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch ignore any exception and set default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">Action async.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value or default value.</returns>
        public static async Task<T> CatchIgnoreAsync<T>(Func<Task<T>> action, T defaultValue = default(T))
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                return await action();
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch ignore specific exception and set default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value or default value.</returns>
        public static T CatchIgnore<T, TException>(Func<T> action, T defaultValue = default(T)) where TException : Exception
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                return action();
            }
            catch (TException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Catch ignore specific exception and set default value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TException">Type of exception.</typeparam>
        /// <param name="action">Action.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Value or default value.</returns>
        public static async Task<T> CatchIgnoreAsync<T, TException>(Func<Task<T>> action, T defaultValue = default(T)) where TException : Exception
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            try
            {
                return await action();
            }
            catch (TException)
            {
                return defaultValue;
            }
        }
    }
}
