using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryFinally_Any
    {
        [Fact]
        public void TryFinally()
        {
            Try.Finally(() => { }, () => { });
        }

        [Fact]
        public void TryFinally2()
        {
            Assert.Throws<InvalidCastException>(() =>
            {
                Try.Finally(() => throw new InvalidCastException(), () => { });
            });
        }

        [Fact]
        public async Task TryFinallyAsync()
        {
            await Try.FinallyAsync(() => Task.CompletedTask, () => { });
        }

        [Fact]
        public async Task TryFinallyAsync2()
        {
            await Assert.ThrowsAsync<InvalidCastException>(async () =>
            {
                await Try.FinallyAsync(() => throw new InvalidCastException(), () => { });
            });
        }
    }
}
