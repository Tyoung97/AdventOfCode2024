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
    public List<int[]> BreakSeal(string path, Func<string,int[]> parselogic) {
        var lines = File.ReadLines(path);
        var breakseallist = lines.Select(parselogic).ToList();
        return breakseallist;
    }
    public List<Tuple<int,int>> BreakSeal(string path, Func<string,Tuple<int,int>> parselogic) {
        var lines = File.ReadLines(path);
        var breakseallist = lines.Select(parselogic).ToList();
        return breakseallist;
    }
    public Location[,] BreakSeal(string path, int value) {
        var lines = File.ReadLines(path).ToList();
        var breakseallist = new Location[lines[0].Length,lines.Count()];
        var x = 0;
        var y = 0;
        foreach(var line in lines) {
            foreach (var chr in line) {
                breakseallist[y,x] = new Location{locationsymbol = chr,locationwalked = value};
                x++;
            }
            x = 0;
            y++;
        }
        return breakseallist;
    }
}