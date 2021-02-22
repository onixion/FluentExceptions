using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatch_Any
    {
        [Fact]
        public void TryCatch()
        {
            Try.Catch(() => { }, e => { });
        }

        [Fact]
        public void TryCatch2()
        {
            var ex = new Exception();
            Try.Catch(() => throw ex, e => Assert.Same(ex, e));
        }

        [Fact]
        public async Task TryCatchAsync()
        {
            await Try.CatchAsync(() => Task.CompletedTask, e => { });
        }

        [Fact]
        public async Task TryCatchAsync2()
        {
            var ex = new Exception();
            await Try.CatchAsync(() => throw ex, e => Assert.Same(ex, e));
        }
    }
}
