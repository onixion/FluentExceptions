﻿using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AlinSpace.FluentExceptions.Tests
{
    /// <summary>
    /// Unit tests for Try-Catch-Finally method variants.
    /// </summary>
    public class TryCatchFinally_Any
    {
        [Fact]
        public void TaskCatchFinally_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            Try.CatchFinally(m.Try, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public void TaskCatchFinally_2()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.Try()).Throws(ex);

            var m = mock.Object;

            // Act
            Try.CatchFinally(m.Try, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.Try(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinally_3()
        {
            // Setup
            var ex = new ArgumentNullException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // Act
                await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.Catch, m.Finally);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<InvalidCastException>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync1_1()
        {
            // Setup
            var mock = new Mock<ITryCatchFinally>();
            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync(m.TryAsync, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync1_2()
        {
            // Setup
            var ex = new Exception();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            // Act
            await Try.CatchFinallyAsync(m.TryAsync, m.Catch, m.Finally);

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<Exception>()), Times.Once);
            mock.Verify(m => m.Finally(), Times.Once);
        }

        [Fact]
        public async Task TaskCatchFinallyAsync1_3()
        {
            // Setup
            var ex = new ArgumentNullException();
            var mock = new Mock<ITryCatchFinally>();
            mock.Setup(m => m.TryAsync()).Throws(ex);

            var m = mock.Object;

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                // Act
                await Try.CatchFinallyAsync<InvalidCastException>(m.TryAsync, m.Catch, m.Finally);
            });

            // Assert
            mock.Verify(m => m.TryAsync(), Times.Once);
            mock.Verify(m => m.Catch(It.IsAny<InvalidCastException>()), Times.Never);
            mock.Verify(m => m.Finally(), Times.Once);
        }
    }
}
