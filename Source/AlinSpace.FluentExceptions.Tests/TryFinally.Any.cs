using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Finally method variants.
    /// </summary>
    public class TryFinally_Any
    {
        [Fact]
        public void TryFinally_1()
        {
            Try.Finally(() => { }, () => { });
        }

        [Fact]
        public void TryFinally_2()
        {
            Assert.Throws<InvalidCastException>(() =>
            {
                Try.Finally(() => throw new InvalidCastException(), () => { });
            });
        }

        [Fact]
        public async Task TryFinallyAsync_1()
        {
            await Try.FinallyAsync(() => Task.CompletedTask, () => { });
        }

        [Fact]
        public async Task TryFinallyAsync_2()
        {
            await Assert.ThrowsAsync<InvalidCastException>(async () =>
            {
                await Try.FinallyAsync(() => throw new InvalidCastException(), () => { });
            });
        }
    }
}
