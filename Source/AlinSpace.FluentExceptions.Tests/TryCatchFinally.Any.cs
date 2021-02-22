using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatchFinally_Any
    {
        [Fact]
        public void TaskCatchFinally()
        {
            Try.CatchFinally(
                () => { },
                e => { },
                () => { });
        }

        [Fact]
        public void TaskCatchFinally2()
        {
            Try.CatchFinally(
                () => throw new Exception(),
                e => { },
                () => { });
        }

        [Fact]
        public async Task TaskCatchFinallyAsync()
        {
            await Try.CatchFinallyAsync(
                () => Task.CompletedTask,
                e => { },
                () => { });
        }

        [Fact]
        public async Task TaskCatchFinallyAsync2()
        {
            await Try.CatchFinallyAsync(
                () => throw new Exception(),
                e => { },
                () => { });
        }
    }
}
