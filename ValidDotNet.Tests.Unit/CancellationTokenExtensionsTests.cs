using System;
using System.Linq;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace ValidDotNet.Tests.Unit;

public class CancellationTokenExtensionsTests
{
    [Fact]
    public void CancellationToken_ThrowIfLessOrEqual_Returns()
    {
        var token = new CancellationTokenSource().Token;
        token.ThrowIfNone().Should().Be(token);
    }

    [Fact]
    public void CancellationToken_ThrowIfLessOrEqual()
    {
        var t = CancellationToken.None;
        Action act = () => t.ThrowIfNone();
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First()
            .Message.Should()
            .Be("Parameter is none! (Parameter 't')");
    }

    [Fact]
    public void CancellationToken_CustomMessage_ThrowIfLessOrEqual()
    {
        var t = CancellationToken.None;
        Action act = () => t.ThrowIfNone(message: "Message");
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First().Message.Should().Be("Message (Parameter 't')");
    }
}