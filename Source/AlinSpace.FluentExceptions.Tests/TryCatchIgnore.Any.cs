using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatchIgnore_Any
    {
        [Fact]
        public void TryCatchIgnore()
        {
            Try.CatchIgnore(() => { });
        }

        [Fact]
        public void TryCatchIgnore2()
        {
            Try.CatchIgnore(() => throw new Exception());
        }

        [Fact]
        public async Task TryCatchIgnoreAsync()
        {
            await Try.CatchIgnoreAsync(() => Task.CompletedTask);
        }

        [Fact]
        public async Task TryCatchIgnoreAsync2()
        {
            await Try.CatchIgnoreAsync(() => throw new Exception());
        }
    }
}
