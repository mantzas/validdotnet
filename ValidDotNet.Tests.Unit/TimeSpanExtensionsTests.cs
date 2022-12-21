using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace ValidDotNet.Tests.Unit;

public class TimeSpanExtensionsTests
{
    [Fact]
    public void TimeSpan_ThrowIfZero_Returns()
    {
        var t = TimeSpan.FromSeconds(1);
        t.ThrowIfZero().Should().Be(t);
    }

    [Fact]
    public void TimeSpan_ThrowIfZero()
    {
        var t = TimeSpan.Zero;
        Action act = () => t.ThrowIfZero();
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First()
            .Message.Should()
            .Be("Parameter is zero! (Parameter 't')");
    }

    [Fact]
    public void TimeSpan_CustomMessage_ThrowIfZero()
    {
        var t = TimeSpan.Zero;
        Action act = () => t.ThrowIfZero(message: "Message");
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First().Message.Should().Be("Message (Parameter 't')");
    }
}