using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    public class TryCatch_Any
    {
        #region TryCatch

        [Fact]
        public void TryCatch_1()
        {
            Try.Catch(() => { }, e => { });
        }

        [Fact]
        public void TryCatch_2()
        {
            var ex = new Exception();
            Try.Catch(() => throw ex, e => Assert.Same(ex, e));
        }

        #endregion

        #region TryCatch Return

        [Fact]
        public void TryCatch_Return_1()
        {
            var returnValue = Try.CatchReturn(() => "Test", e => { });
            Assert.Equal("Test", returnValue);
        }

        [Fact]
        public void TryCatch_Return_2()
        {
            var ex = new Exception();
            var returnValue = Try.CatchReturn(() => throw ex, e => Assert.Same(ex, e), defaultValue: "Test");
            Assert.Equal("Test", returnValue);
        }

        #endregion

        #region TryCatch Async 1

        [Fact]
        public async Task TryCatchAsync1_1()
        {
            await Try.CatchAsync(() => Task.CompletedTask, e => { });
        }

        [Fact]
        public async Task TryCatchAsync1_2()
        {
            var ex = new Exception();
            await Try.CatchAsync(() => throw ex, e => Assert.Same(ex, e));
        }

        #endregion

        #region TryCatch Async 1 Return

        [Fact]
        public async Task TryCatchAsync1_1_Return()
        {
            var returnValue = await Try.CatchReturnAsync(() => Task.FromResult("Test"), e => { });
            Assert.Equal("Test", returnValue);
        }

        [Fact]
        public async Task TryCatchAsync1_2_Return()
        {
            var ex = new Exception();
            var returnValue = await Try.CatchReturnAsync(() => throw ex, e => Assert.Same(ex, e), defaultValue: "Test");
            Assert.Equal("Test", returnValue);
        }

        #endregion

        #region TryCatch Async 2

        [Fact]
        public async Task TryCatchAsync2_1()
        {
            await Try.CatchAsync(() => Task.CompletedTask, e => Task.CompletedTask);
        }

        [Fact]
        public async Task TryCatchAsync2_2()
        {
            var ex = new Exception();
            await Try.CatchAsync(() => throw ex, e => { Assert.Same(ex, e); return Task.CompletedTask; });
        }

        #endregion

        #region TryCatch Async 2 Return

        [Fact]
        public async Task TryCatchAsync2_1_Return()
        {
            var returnValue = await Try.CatchReturnAsync(() => Task.FromResult("Test"), e => Task.CompletedTask);
            Assert.Equal("Test", returnValue);
        }

        [Fact]
        public async Task TryCatchAsync2_2_Return()
        {
            var ex = new Exception();
            var returnValue = await Try.CatchReturnAsync(() => throw ex, e => { Assert.Same(ex, e); return Task.CompletedTask; }, defaultValue: "Test");
            Assert.Equal("Test", returnValue);
        }

        #endregion
    }
}
