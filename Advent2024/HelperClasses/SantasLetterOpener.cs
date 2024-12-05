using System.Linq.Expressions;

namespace Advent2024;

public class SantasLetterOpener {
    public List<int> BreakSeal(string path, Func<string,int> parselogic) {
        var lines = File.ReadLines(path);
        var breakseallist = lines.Select(parselogic).ToList();
        return breakseallist;
    }
    public IEnumerable<string> BreakSeal(string path) {
        var lines = File.ReadLines(path);
        return lines;
    }
    public string BreakSeal(string path, Func<string, string, string> parselogic) {
        var lines = File.ReadLines(path);
        var fullline = lines.Aggregate(parselogic);
        return fullline;
    }
}