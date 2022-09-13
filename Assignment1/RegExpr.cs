using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
     public static IEnumerable<string> SplitLine(IEnumerable<string> lines){
        var pattern = @"([a-zA-Z0-9]+)";
        foreach(string s in lines){
            foreach(Match m in Regex.Matches(s, pattern)){
                yield return m.Value;
            }
           }
        }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions){
        var pattern = @"(?<width>[0-9]+)x(?<height>[0-9]+)";
        foreach(string s in resolutions){
            var match = Regex.Match(s, pattern);
            if(match.Success){
                 Console.WriteLine((int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value)));
                 yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            }
               
            }
           }

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();

    public static IEnumerable<(Uri url, string title)> Urls(string html) => throw new NotImplementedException();
}