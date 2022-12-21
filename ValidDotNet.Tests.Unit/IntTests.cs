using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace ValidDotNet.Tests.Unit;

public class IntExtensionsTests
{
    [Fact]
    public void Int_ThrowIfLessOrEqual_Returns()
    {
        1.ThrowIfLessOrEqual(0).Should().Be(1);
    }

    [Fact]
    public void Int_ThrowIfLessOrEqual()
    {
        var t = 0;
        Action act = () => t.ThrowIfLessOrEqual(0);
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First()
            .Message.Should()
            .Be("Parameter is less or equal to 0! (Parameter 't')");
    }

    [Fact]
    public void Int_CustomMessage_ThrowIfLessOrEqual()
    {
        var t = 0;
        Action act = () => t.ThrowIfLessOrEqual(0, message: "Message");
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First().Message.Should().Be("Message (Parameter 't')");
    }
}