using System;
using System.Threading.Tasks;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// The purpose of this interface is to track delegate 
    /// calls by the Moq library.
    /// </summary>
    public interface ITryCatchFinally
    {
        void Try();

        TReturn Try<TReturn>();

        Task TryAsync();

        Task<TReturn> TryAsync<TReturn>();

        void Catch(Exception e);

        void Catch<TException>(TException e);

        Task CatchAsync(Exception e);

        Task CatchAsync<TException>(TException e);

        void Finally();

        Task FinallyAsync();
    }
}
