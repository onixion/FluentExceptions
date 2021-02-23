using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Catch method variants.
    /// </summary>
    public class TryCatch_Any
    {
        #region TryCatch

        [Fact]
        public void TryCatch_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.Catch(m.Try, m.Catch);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public void TryCatch_2()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            // Act
            Try.Catch(m.Try, m.Catch);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<Exception>(e => ReferenceEquals(e, ex))), 
                Times.Once);
        }

        #endregion

        #region TryCatch Return

        [Fact]
        public void TryCatch_Return_1()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try<string>()).Returns("Test");

            var m = mock.Object;

            // Act
            var returnValue = Try.CatchReturn(m.Try<string>, m.Catch);

            // Assert
            Assert.Equal("Test", returnValue);

            mock.Verify(m => m.Try<string>(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public void TryCatch_Return_2()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try<string>()).Throws(ex);
            
            var m = mock.Object;

            // Act
            var returnValue = Try.CatchReturn(m.Try<string>, m.Catch, defaultValue: "Test");
            
            // Assert
            Assert.Equal("Test", returnValue);

            mock.Verify(m => m.Try<string>(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<Exception>(e => ReferenceEquals(e, ex))),
                Times.Once);
        }

        #endregion

        #region TryCatch Async 1

        [Fact]
        public async Task TryCatchAsync1_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchAsync(m.TryAsync, m.Catch);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync1_2()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchAsync(m.TryAsync, m.Catch);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<Exception>(e => ReferenceEquals(e, ex))), 
                Times.Once);
        }

        #endregion

        #region TryCatch Async 1 Return

        [Fact]
        public async Task TryCatchAsync1_1_Return()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync<string>()).Returns(Task.FromResult("Test"));

            var m = mock.Object;

            // Act
            var returnValue = await Try.CatchReturnAsync(m.TryAsync<string>, m.Catch);
            
            // Assert
            Assert.Equal("Test", returnValue);
            mock.Verify(m => m.TryAsync<string>(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync1_2_Return()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync<string>()).Throws(ex);

            var m = mock.Object;

            // Act
            var returnValue = await Try.CatchReturnAsync(m.TryAsync<string>, m.Catch, defaultValue: "Test");
            
            // Assert
            Assert.Equal("Test", returnValue);
            mock.Verify(m => m.TryAsync<string>(), Times.Once);
            mock.Verify(
                m => m.Catch(It.Is<Exception>(e => ReferenceEquals(e, ex))),
                Times.Once);
        }

        #endregion

        #region TryCatch Async 2

        [Fact]
        public async Task TryCatchAsync2_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchAsync(m.TryAsync, m.CatchAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.CatchAsync(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync2_2()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchAsync(m.TryAsync, m.CatchAsync);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(
                m => m.CatchAsync(It.Is<Exception>(e => ReferenceEquals(e, ex))), 
                Times.Once);

        }

        #endregion

        #region TryCatch Async 2 Return

        [Fact]
        public async Task TryCatchAsync2_1_Return()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync<string>()).Returns(Task.FromResult("Test"));

            var m = mock.Object;

            // Act
            var returnValue = await Try.CatchReturnAsync(m.TryAsync<string>, m.Catch);

            // Assert
            Assert.Equal("Test", returnValue); 
            mock.Verify(m => m.TryAsync<string>(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
        }

        [Fact]
        public async Task TryCatchAsync2_2_Return()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync<string>()).Throws(ex);

            var m = mock.Object;

            // Act
            var returnValue = await Try.CatchReturnAsync(m.TryAsync<string>, m.CatchAsync, defaultValue: "Test");

            // Assert
            Assert.Equal("Test", returnValue);
            mock.Verify(m => m.TryAsync<string>(), Times.Once);
            mock.Verify(
                m => m.CatchAsync(It.Is<Exception>(e => ReferenceEquals(e, ex))), 
                Times.Once);
        }

        #endregion
    }
}
