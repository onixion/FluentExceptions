using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Catch method variants (with specific exceptions).
    /// </summary>
    public class TryCatch_Specific
    {
        [Fact]
        public void TryCatch_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.Catch<InvalidCastException>(m.Try, m.Catch);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(
                m => m.Catch(It.IsAny<InvalidCastException>()), 
                Times.Never);
        }

        [Fact]
        public void TryCatch_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            // Act
            Try.Catch<InvalidCastException>(m.Try, m.Catch);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<InvalidCastException>(e => ReferenceEquals(e, ex))),
                Times.Once);
        }

        [Fact]
        public void TryCatch_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                // Act
                Try.Catch<InvalidCastException>(m.Try, m.Catch);
            });

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync1_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchAsync<InvalidCastException>(m.TryAsync, m.Catch);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync1_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchAsync<InvalidCastException>(m.TryAsync, m.Catch);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<InvalidCastException>()), Times.Once);
        }

        [Fact]
        public async Task TryCatchAsync1_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await Try.CatchAsync<InvalidCastException>(m.TryAsync, m.Catch);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<InvalidCastException>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync2_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchAsync<InvalidCastException>(m.TryAsync, m.CatchAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.CatchAsync(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync2_2()
        {
            // Setup
            var ex = new InvalidCastException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchAsync<InvalidCastException>(m.TryAsync, m.CatchAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.CatchAsync(It.IsAny<InvalidCastException>()), Times.Once);
        }

        [Fact]
        public async Task TryCatchAsync2_3()
        {
            // Setup
            var ex = new ArgumentOutOfRangeException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await Try.CatchAsync<InvalidCastException>(m.TryAsync, m.CatchAsync);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.CatchAsync(It.IsAny<InvalidCastException>()), Times.Never);
        }
    }
}
