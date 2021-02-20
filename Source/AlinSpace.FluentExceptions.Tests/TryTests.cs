using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for <see cref="Try"/>.
    /// </summary>
    public class TryTests
    {
        [Fact]
        public void CatchIgnore()
        {
            Try.CatchIgnore(() => { });
        }

        [Fact]
        public void CatchIgnore2()
        {
            Try.CatchIgnore(() => throw new Exception());
        }

        [Fact]
        public async Task CatchIgnoreAsync()
        {
            await Try.CatchIgnoreAsync(() => Task.CompletedTask);
        }

        [Fact]
        public async Task CatchIgnoreAsync2()
        {
            await Try.CatchIgnoreAsync(() => throw new Exception());
        }
    }
}
