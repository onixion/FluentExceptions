using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Catch-Finally method variants (with specific exceptions).
    /// </summary>
    public class TryCatchFinally_Specific
    {
        [Fact]
        public void TaskCatchFinally_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.CatchFinally<InvalidCastException>(m.Try, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<InvalidCastException>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public void TaskCatchFinally_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            // Act
            Try.CatchFinally<InvalidCastException>(m.Try, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))), 
                Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public void TaskCatchFinally_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                // Act
                Try.CatchFinally<InvalidCastException>(m.Try, m.Catch, m.Finally);
            });

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync1_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<InvalidCastException>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync1_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))), 
                Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync1_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                // Act
                await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.Catch, m.Finally);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync2_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.CatchAsync, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.CatchAsync(It.IsAny<InvalidCastException>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync2_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.CatchAsync, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.CatchAsync(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync2_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                // Act
                await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.CatchAsync, m.Finally);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.CatchAsync(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync3_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.CatchAsync, m.FinallyAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.CatchAsync(It.IsAny<InvalidCastException>()), Times.Never);
            mock.Verify(m => m.FinallyAsync(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync3_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.CatchAsync, m.FinallyAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.CatchAsync(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Once);
            mock.Verify(m => m.FinallyAsync(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync3_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                // Act
                await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.CatchAsync, m.FinallyAsync);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.CatchAsync(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Never);
            mock.Verify(m => m.FinallyAsync(), Times.Once);
        }
    }
}
