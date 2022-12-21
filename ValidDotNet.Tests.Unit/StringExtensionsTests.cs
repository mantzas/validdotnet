using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace ValidDotNet.Tests.Unit;

public class StringExtensionsTests
{
    [Fact]
    public void String_ThrowIfNullOrWhitespace_Returns()
    {
        const string t = "Test";
        t.ThrowIfNullOrWhitespace().Should().Be(t);
    }

    [Fact]
    public void String_ThrowIfNullOrWhitespace()
    {
        var t = string.Empty;
        Action act = () => t.ThrowIfNullOrWhitespace();
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First()
            .Message.Should()
            .Be("Parameter is null or whitespace! (Parameter 't')");
    }

    [Fact]
    public void String_CustomMessage_ThrowIfNullOrWhitespace()
    {
        var t = string.Empty;
        Action act = () => t.ThrowIfNullOrWhitespace(message: "Message");
        var result = act.Should().Throw<ArgumentException>();
        result.Subject.First().Message.Should().Be("Message (Parameter 't')");
    }
}