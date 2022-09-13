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
                 // Console.WriteLine((int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value)));
                 yield return (int.Parse(match.Groups["width"].Value), int.Parse(match.Groups["height"].Value));
            }
               
            }
           }

    public static IEnumerable<string> InnerText(string html, string tag) {

        // $"<({ tag }).*?>(.*?)</(\1)>"
        
        var tagInnerPattern = $"<({ tag }).*?>(?<inner>.*?)</(\\1)>";
        foreach (Match m in Regex.Matches(html, tagInnerPattern)) {
            yield return Regex.Replace(m.Groups["inner"].Value, "<.*?>", "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html) {

        var urlAndTitlePattern = @"<a *((title=[""'](?<title>[^""']*)[""'] *)|([^= ]*=[""'][^""']*[""'] *))* *(href=[""'](?<url>[^""']*)[""']) *((title=[""'](?<title>[^""']*)[""'] *)|([^= ]*=[""'][^""']*[""'] *))* *>(?<inner>.*?)</a>"; 
        foreach (Match m in Regex.Matches(html, urlAndTitlePattern)) {
            if (m.Groups["title"].Value != "") {
                yield return (new Uri(m.Groups["url"].Value), m.Groups["title"].Value);
            } else {
                yield return (new Uri(m.Groups["url"].Value), m.Groups["inner"].Value);
            }
        }

    }
}