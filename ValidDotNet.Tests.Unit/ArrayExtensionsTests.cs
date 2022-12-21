using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace ValidDotNet.Tests.Unit;

public class ArrayExtensionsTests
{
    [Fact]
    public void Array_ThrowIfNullOrEmpty_returns()
    {
        var t = new[] { "1", "2" };
        t.ThrowIfNullOrEmpty().Should().Equal(t);
    }

    [Fact]
    public void Array_customMessage_ThrowIfNullOrEmpty()
    {
        string[]? t = null;
        Action act = () => t!.ThrowIfNullOrEmpty(message: "Message");
        var result = act.Should().Throw<ArgumentNullException>();
        result.Subject.First().Message.Should().Be("Message (Parameter 't')");
    }
}

