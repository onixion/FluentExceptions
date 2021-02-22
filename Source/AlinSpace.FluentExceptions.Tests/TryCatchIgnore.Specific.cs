using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatchIgnore_Specific
    {
        [Fact]
        public void TryCatchIgnore()
        {
            Try.CatchIgnore<InvalidCastException>(() => { });
        }

        [Fact]
        public void TryCatchIgnore2()
        {
            Try.CatchIgnore<InvalidCastException>(
                () => throw new InvalidCastException());
        }

        [Fact]
        public void TryCatchIgnore3()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Try.CatchIgnore<InvalidCastException>(
                    () => throw new ArgumentOutOfRangeException());
            });
        }

        [Fact]
        public async Task TryCatchIgnoreAsync()
        {
            await Try.CatchIgnoreAsync<InvalidCastException>(() => Task.CompletedTask);
        }

        [Fact]
        public async Task TryCatchIgnoreAsync2()
        {
            await Try.CatchIgnoreAsync<InvalidCastException>(
                () => throw new InvalidCastException());
        }

        [Fact]
        public async Task TryCatchIgnoreAsync3()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await Try.CatchIgnoreAsync<InvalidCastException>(
                    () => throw new ArgumentOutOfRangeException());
            });
        }
    }
}
