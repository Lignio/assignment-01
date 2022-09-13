using FluentAssertions;
using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
     [Fact]
    public void SplitLineMethod_3StringsTo10Strings()
    {
        //Assign
        string[] test = {"text test string", "animal dog cat", "math 22+23-result"};
    
        //Act
        var check = RegExpr.SplitLine(test);
    
        //Assert
        check.Should().BeEquivalentTo(new [] {"text", "test", "string", "animal", "dog", "cat", "math", "22", "23", "result"});
    }

    [Fact]
    public void ResolutionsMethod_ResolutionsOfFormat_NUMBERxNUMBER()
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
    public void InnerTextMethod_InnerTextOfLinks()
    {
        //Assign
        string html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='https://en.wikipedia.org/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='https://en.wikipedia.org/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='https://en.wikipedia.org/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='https://en.wikipedia.org/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='https://en.wikipedia.org/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='https://en.wikipedia.org/wiki/String_(computer_science)' title='String (computer science)'>strings</a>.</p></div>";
        string tag = "a";

        //Act
        var innerText = RegExpr.InnerText(html, tag);

        //Assert
        innerText.Should().BeEquivalentTo(new [] {"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"});
        // Assert.Equal(new [] {"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"}, innerText);
    }

    [Fact]
    public void InnerTextMethod_InnerTextOfParagraph_SingleElementInArray()
    {
        //Assign
        string html = "<div><p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p></div>";
        string tag = "p";

        //Act
        var innerText = RegExpr.InnerText(html, tag);

        //Assert
        innerText.Should().BeEquivalentTo(new [] {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."});
        // Assert.Equal(new [] {"theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings"}, innerText);
    }

    [Fact]
    public void UrlsMethod_ReturnsUrlsWithTitles() {

        // Assign
        string html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='https://en.wikipedia.org/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='https://en.wikipedia.org/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='https://en.wikipedia.org/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='https://en.wikipedia.org/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='https://en.wikipedia.org/wiki/String_searching_algorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='https://en.wikipedia.org/wiki/String_(computer_science)' title='String (computer science)'>strings</a>.</p></div>";

        // Act
        var urlOrInnerText = RegExpr.Urls(html);

        // Assert
        urlOrInnerText.Should().BeEquivalentTo(new [] {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"), (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"), (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"), (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"), (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")});
        // Assert.Equal(new [] {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"), (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"), (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"), (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"), (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "String (computer science)")}, urlOrInnerText);
    }

    [Fact]
    public void UrlsMethod_ReturnsUrlsWithTitlesLastLinkNoTitle() {

        // Assign
        string html = "<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='https://en.wikipedia.org/wiki/Theoretical_computer_science' abc='jaba' title='Theoretical computer science'>theoretical computer science</a> and <a href='https://en.wikipedia.org/wiki/Formal_language' title='Formal language'>formal language</a> theory, a sequence of <a href='https://en.wikipedia.org/wiki/Character_(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='https://en.wikipedia.org/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a title='String searching algorithm' href='https://en.wikipedia.org/wiki/String_searching_algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='https://en.wikipedia.org/wiki/String_(computer_science)'>strings</a>.</p></div>";

        // Act
        var urlOrInnerText = RegExpr.Urls(html);

        // Assert
        // urlOrInnerText.Should().BeEquivalentTo(new [] {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"), (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"), (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"), (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"), (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "strings")});
        Assert.Equal(new [] {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"), "Theoretical computer science"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"), (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"), (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"), (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"), "String searching algorithm"), (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"), "strings")}, urlOrInnerText);
    }
}