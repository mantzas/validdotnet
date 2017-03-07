using System;
using System.Threading;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace ValidDotNet.Tests.Unit
{
    public class ParameterValidationExtensionsTests
    {
        #region Generic as class

        [Fact]
        public void GenericClass_ThrowIfNull_Returns()
        {
            var t = new { Name = "Test" };
            t.ThrowIfNull("t").Should().Be(t);
        }

        [Fact]
        public void GenericClass_ThrowIfNull()
        {
            Action act = () => ((object) null).ThrowIfNull("t");
            var result = act.ShouldThrow<ArgumentNullException>();
            result.Subject.First()
                .Message.Should()
                .Be("Parameter is null!" + Environment.NewLine + "Parameter name: t");
        }

        [Fact]
        public void GenericClass_customMessage_ThrowIfNull()
        {
            Action act = () => ((object) null).ThrowIfNull("t", "Message");
            var result = act.ShouldThrow<ArgumentNullException>();
            result.Subject.First().Message.Should().Be("Message" + Environment.NewLine + "Parameter name: t");
        }

        #endregion

        #region TimeSpan

        [Fact]
        public void TimeSpan_ThrowIfZero_Returns()
        {
            var t = TimeSpan.FromSeconds(1);
            t.ThrowIfZero("t").Should().Be(t);
        }

        [Fact]
        public void TimeSpan_ThrowIfZero()
        {
            Action act = () => TimeSpan.Zero.ThrowIfZero("t");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First()
                .Message.Should()
                .Be("Parameter is zero!" + Environment.NewLine + "Parameter name: t");
        }

        [Fact]
        public void TimeSpan_CustomMessage_ThrowIfZero()
        {
            Action act = () => TimeSpan.Zero.ThrowIfZero("t", "Message");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First().Message.Should().Be("Message" + Environment.NewLine + "Parameter name: t");
        }

        #endregion

        #region String

        [Fact]
        public void String_ThrowIfNullOrWhitespace_Returns()
        {
            var t = "Test";
            t.ThrowIfNullOrWhitespace("t").Should().Be(t);
        }

        [Fact]
        public void String_ThrowIfNullOrWhitespace()
        {
            Action act = () => string.Empty.ThrowIfNullOrWhitespace("t");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First()
                .Message.Should()
                .Be("Parameter is null or whitespace!" + Environment.NewLine + "Parameter name: t");
        }

        [Fact]
        public void String_CustomMessage_ThrowIfNullOrWhitespace()
        {
            Action act = () => string.Empty.ThrowIfNullOrWhitespace("t", "Message");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First().Message.Should().Be("Message" + Environment.NewLine + "Parameter name: t");
        }

        #endregion

        #region int

        [Fact]
        public void Int_ThrowIfLessOrEqual_Returns()
        {
            1.ThrowIfLessOrEqual("t", 0).Should().Be(1);
        }

        [Fact]
        public void Int_ThrowIfLessOrEqual()
        {
            Action act = () => 0.ThrowIfLessOrEqual("t", 0);
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First()
                .Message.Should()
                .Be("Parameter is less or equal to 0!" + Environment.NewLine + "Parameter name: t");
        }

        [Fact]
        public void Int_CustomMessage_ThrowIfLessOrEqual()
        {
            Action act = () => 0.ThrowIfLessOrEqual("t", 0, "Message");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First().Message.Should().Be("Message" + Environment.NewLine + "Parameter name: t");
        }

        #endregion

        #region CancellationToken

        [Fact]
        public void CancellationToken_ThrowIfLessOrEqual_Returns()
        {
            var token = new CancellationTokenSource().Token;
            token.ThrowIfNone("t").Should().Be(token);
        }

        [Fact]
        public void CancellationToken_ThrowIfLessOrEqual()
        {
            Action act = () => CancellationToken.None.ThrowIfNone("t");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First()
                .Message.Should()
                .Be("Parameter is none!" + Environment.NewLine + "Parameter name: t");
        }

        [Fact]
        public void CancellationToken_CustomMessage_ThrowIfLessOrEqual()
        {
            Action act = () => CancellationToken.None.ThrowIfNone("t", "Message");
            var result = act.ShouldThrow<ArgumentException>();
            result.Subject.First().Message.Should().Be("Message" + Environment.NewLine + "Parameter name: t");
        }

        #endregion
    }
}