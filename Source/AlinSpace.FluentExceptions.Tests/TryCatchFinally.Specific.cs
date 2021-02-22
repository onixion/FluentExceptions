using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatchFinally_Specific
    {
        [Fact]
        public void TaskCatchFinally()
        {
            Try.CatchFinally<InvalidCastException>(
                () => { },
                e => { },
                () => { });
        }

        [Fact]
        public void TaskCatchFinally2()
        {
            Try.CatchFinally<InvalidCastException>(
                () => throw new InvalidCastException(),
                e => { },
                () => { });
        }

        [Fact]
        public void TaskCatchFinally3()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Try.CatchFinally<InvalidCastException>(
                    () => throw new ArgumentOutOfRangeException(),
                    e => { },
                    () => { });
            });
        }

        [Fact]
        public async Task TaskCatchFinallyAsync()
        {
            await Try.CatchFinallyAsync<InvalidCastException>(
                () => Task.CompletedTask,
                e => { },
                () => { });
        }

        [Fact]
        public async Task TaskCatchFinallyAsync2()
        {
            await Try.CatchFinallyAsync<InvalidCastException>(
                () => throw new InvalidCastException(),
                e => { },
                () => { });
        }

        [Fact]
        public async Task TaskCatchFinallyAsync3()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await Try.CatchFinallyAsync<InvalidCastException>(
                    () => throw new ArgumentOutOfRangeException(),
                    e => { },
                    () => { });
            });
        }
    }
}
