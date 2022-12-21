using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace ValidDotNet.Tests.Unit;

public class GenericExtensionsTests
{
    [Fact]
    public void GenericClass_ThrowIfNull_Returns()
    {
        var t = new { Name = "Test" };
        t.ThrowIfNull().Should().Be(t);
    }

    [Fact]
    public void GenericClass_ThrowIfNull()
    {
        object? t = null;
        Action act = () => t.ThrowIfNull();
        var result = act.Should().Throw<ArgumentNullException>();
        result.Subject.First()
            .Message.Should()
            .Be("Parameter is null! (Parameter 't')");
    }

    [Fact]
    public void GenericClass_customMessage_ThrowIfNull()
    {
        object? t = null;
        Action act = () => t.ThrowIfNull(message: "Message");
        var result = act.Should().Throw<ArgumentNullException>();
        result.Subject.First().Message.Should().Be("Message (Parameter 't')");
    }
}
