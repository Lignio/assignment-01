using FluentAssertions;
using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
     [Fact]
    public void TestSplitLine()
    {
        //Assign
        string[] test = {"text test string", "animal dog cat", "math 22+23-result"};
    
        //Act
        var check = RegExpr.SplitLine(test);
    
        //Assert
        check.Should().BeEquivalentTo(new [] {"text", "test", "string", "animal", "dog", "cat", "math", "22", "23", "result"});
    }

    [Fact]
    public void TestResolutions()
    {
        //Assign
        string[] test = {"1920x1080", "720x1080", "4000x2000", "100000x3"};
    
        //Act
        var check = RegExpr.Resolution(test);
    
        //Assert
        Console.WriteLine(check);
        //Assert.Equal(new[] {(1920, 1080),(720, 1080),(4000, 2000),(100000, 3)}, check);
        check.Should().BeEquivalentTo(new[] {(1920, 1080),(720, 1080),(4000, 2000),(100000, 3)});
    }

    [Fact]
    public void TestInnerText()
    {
        //Assign
        string[] test = {""};
    
        //Act
    
        //Assert
    }
}