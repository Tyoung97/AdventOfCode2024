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
    public Dictionary<long,int[]> BreakSeal(string path, char firstsplit, char secondsplit) {
        var breaksealdict = new Dictionary<long,int[]>();
        var lines = File.ReadLines(path);
        foreach(var line in lines) {
            breaksealdict.Add(long.Parse(line.Substring(0,line.IndexOf(firstsplit))),line.Substring(line.IndexOf(firstsplit)+1,line.Length-line.IndexOf(firstsplit)-1).Trim().Split(secondsplit).Select(int.Parse).ToArray());
        }
        return breaksealdict;
    }
    public char[,] FileTo2dCharArray(string path){
        var x = 0;
        var y = 0;
        var lines = File.ReadLines(path).ToList();
        var CharArray = new char[lines.Count,lines[0].Length];
        foreach(var line in lines){
            foreach(var symbol in line){
                CharArray[y,x] = symbol;
                x++;
            }
            x = 0;
            y++;
        }
        return CharArray;
    }
    public char[] ReadinStringToCharArray(string path){
        var arrayposition = 0;
        var lines = File.ReadLines(path).ToList();
        var CharArray = new char[lines[0].Length];
        foreach(var character in lines[0]){
            CharArray[arrayposition] = character;
            arrayposition++;
        }
        return CharArray;
    }
}