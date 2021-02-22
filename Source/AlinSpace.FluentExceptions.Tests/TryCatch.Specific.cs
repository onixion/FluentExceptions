using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatch_Specific
    {
        [Fact]
        public void TryCatch()
        {
            Try.Catch<InvalidCastException>(() => { }, e => { });
        }

        [Fact]
        public void TryCatch2()
        {
            Try.Catch<InvalidCastException>(
                () => throw new InvalidCastException(), 
                e => Assert.IsType<InvalidCastException>(e));
        }

        [Fact]
        public void TryCatch3()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Try.Catch<InvalidCastException>(
                    () => throw new ArgumentOutOfRangeException(),
                    e => { });
            });
        }

        [Fact]
        public async Task TryCatchAsync()
        {
            await Try.CatchAsync<InvalidCastException>(() => Task.CompletedTask, e => { });
        }

        [Fact]
        public async Task TryCatchAsync2()
        {
            await Try.CatchAsync<InvalidCastException>(
                () => throw new InvalidCastException(),
                e => Assert.IsType<InvalidCastException>(e));
        }

        [Fact]
        public async Task TryCatchAsync3()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await Try.CatchAsync<InvalidCastException>(
                    () => throw new ArgumentOutOfRangeException(),
                    e => { });
            });
        }
    }
}
