using FluentAssertions;
using Xunit;

namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void TestFlatten()
    {
        // assign
        int[][] test2 = {new[]{1,2,3,4,5}, new[]{6,7,8,9,10}};
        // act
        var check = Iterators.Flatten(test2);
    
        // assert
        check.Should().BeEquivalentTo(new [] {1,2,3,4,5,6,7,8,9,10});
    }

    [Fact]
    public void TestFilter()
    {
        //assign
        int[] test = {1,2,3,4,5,6};
        Predicate<int> predicate = isEven;  
    
        //act
        var check = Iterators.Filter(test, predicate);

    
        //assert
        check.Should().BeEquivalentTo(new[]{2,4,6});
    }

    public static bool isEven(int s) => s%2==0;
}