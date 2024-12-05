using System.Linq.Expressions;

namespace Advent2024;

public class SantasReadingGlasses {
    public List<Tuple<int, int>> Squint(string input) {
        var splits = input.Split("mul(").ToList();
        var parsedfactors = new List<Tuple<int, int>>();
        foreach(var split in splits) {
            // Console.WriteLine("parsing the following split: "+split);
            var pairs = split.Split(')').ToList();
            foreach (var pair in pairs) {
                // Console.WriteLine("Parsed pair from split: "+pair);
                var factors = pair.Split(",").ToList();
                if (factors.Count == 2) {
                    // Console.WriteLine("Found these factors: "+factors[0] +" "+ factors[1]);
                    if (int.TryParse(factors[0], out var firstfactor) && int.TryParse(factors[1], out var secondfactor)) {
                        parsedfactors.Add(new Tuple<int, int>(firstfactor, secondfactor));
                    }
                }
            }
        }
        return parsedfactors;
    }
    public List<int[]> Squint(string input, int enabled) {
        var isenabled = enabled;
        var splits = input.Split("mul(").ToList();
        var parsedfactors = new List<int[]>();
        foreach(var split in splits) {
            if (split.Contains("do()") && split.IndexOf(')') > split.IndexOf("do()")) {
                // Console.WriteLine("Turned on");
                isenabled = 1;
            }
            if (split.Contains("don't()") && split.IndexOf(')') > split.IndexOf("don't()")) {
                isenabled = 0;
                // Console.WriteLine("Turned off");
            }
            // Console.WriteLine("parsing the following split: "+split);
            var pairs = split.Split(')').ToList();
            foreach (var pair in pairs) {
                // Console.WriteLine("Parsed pair from split: "+pair);
                var factors = pair.Split(",").ToList();
                if (factors.Count == 2) {
                    // Console.WriteLine("Found these factors: "+factors[0] +" "+ factors[1]);
                    if (int.TryParse(factors[0], out var firstfactor) && int.TryParse(factors[1], out var secondfactor)) {
                        parsedfactors.Add([isenabled,firstfactor, secondfactor]);
                    }
                }
            }
            if (split.Contains("do()") && split.IndexOf(')') < split.IndexOf("do()")) {
                // Console.WriteLine("Turned on");
                isenabled = 1;
            }
            if (split.Contains("don't()") && split.IndexOf(')') < split.IndexOf("don't()")) {
                isenabled = 0;
                // Console.WriteLine("Turned off");
            }
        }
        return parsedfactors;
    }
}